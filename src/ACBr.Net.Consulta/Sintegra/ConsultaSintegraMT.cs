// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 07-05-2017
//
// Last Modified By : RFTD
// Last Modified On : 07-05-2017
// ***********************************************************************
// <copyright file="ConsultaSintegraMT.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2014 - 2017 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.Sintegra
{
    internal class ConsultaSintegraMT : ConsultaSintegraBase<ConsultaSintegraMT>
    {
        #region Fields

        private const string URL_BASE = @"https://www.sefaz.mt.gov.br/sid/consulta/infocadastral/consultar/publica";
        private const string URL_CAPTCHA = @"https://www.sefaz.mt.gov.br/sid/consulta/geradorcaracteres";
        private const string URL_CONSULTA = @"https://www.sefaz.mt.gov.br/sid/consulta/infocadastral/consultar/publica";

        #endregion Fields

        #region Methods

        public override Image GetCaptcha()
        {
            var request = GetClient(URL_BASE);
            request.Referer = "https://www.sefaz.mt.gov.br/sid/consulta/infocadastral/consultar/publica";

            var response = request.GetResponse();

            string htmlResult;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                htmlResult = reader.ReadToEnd();
            }

            if (htmlResult.Length < 1) return null;

            var url = $"{URL_CAPTCHA}{htmlResult.GetStrBetween("geradorcaracteres", "\"")}";
            request = GetClient(url);
            response = request.GetResponse();

            var captchaStream = response.GetResponseStream();
            Guard.Against<ACBrCaptchaException>(captchaStream.IsNull(), "Erro ao carregar captcha");

            return Image.FromStream(captchaStream);
        }

        public override ACBrEmpresa Consulta(string cnpj, string ie, string captcha)
        {
            var request = GetClient(URL_CONSULTA);

            var postData = new Dictionary<string, string>();

            if (!cnpj.IsEmpty())
            {
                postData.Add("opcao", "2");
                postData.Add("numero", cnpj.OnlyNumbers());
            }
            else
            {
                postData.Add("opcao", "1");
                postData.Add("numero", ie.OnlyNumbers());
            }

            postData.Add("captchaDigitado", captcha);
            postData.Add("pagn", "resultado");
            postData.Add("captcha", "telaComCaptcha");

            var retorno = request.SendPost(postData);

            Guard.Against<ACBrCaptchaException>(retorno.Contains("Código de caracteres inválido!"), "O Texto digitado não confere com a Imagem.");
            Guard.Against<ACBrException>(retorno.Contains("Nenhum resultado encontrado"), $"Não existe no Cadastro do sintegra o número de CNPJ/IE informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
            Guard.Against<ACBrException>(retorno.Contains("a. No momento não podemos atender a sua solicitação. Por favor tente mais tarde."), "Erro no site do sintegra. Tente mais tarde.");
            Guard.Against<ACBrException>(retorno.Contains("Atenção"), "Erro ao fazer a consulta");

            return ProcessResponse(retorno);
        }

        #region Private Methods

        private static ACBrEmpresa ProcessResponse(string retorno)
        {
            var result = new ACBrEmpresa();

            try
            {
                var dadosRetorno = new List<string>();
                retorno = HttpUtility.HtmlDecode(retorno);
                retorno = retorno.StripHtml();
                dadosRetorno.AddText(retorno.Replace("&nbsp;", Environment.NewLine));
                dadosRetorno.RemoveEmptyLines();

                result.CNPJ = LerCampo(dadosRetorno, "CPF/CNPJ:");
                result.InscricaoEstadual = LerCampo(dadosRetorno, "Inscrição estadual:");
                result.RazaoSocial = LerCampo(dadosRetorno, "Razão social:").Replace("amp;", string.Empty);
                result.Logradouro = LerCampo(dadosRetorno, "Logradouro:");
                result.Numero = LerCampo(dadosRetorno, "Número:");
                result.Complemento = LerCampo(dadosRetorno, "Complemento:");
                result.Bairro = LerCampo(dadosRetorno, "Bairro:");
                result.Municipio = LerCampo(dadosRetorno, "Município/UF:");
                result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(dadosRetorno, result.Municipio).ToUpper());
                result.Municipio = result.Municipio.Substring(0, result.Municipio.Length - 2);
                result.CEP = LerCampo(dadosRetorno, "CEP:").FormataCEP();
                result.Telefone = LerCampo(dadosRetorno, "Telefone:");
                result.AtividadeEconomica = LerCampo(dadosRetorno, "Atividade Econômica:");
                result.DataAbertura = LerCampo(dadosRetorno, "Data de início no Simples Nacional:").ToData();
                result.Situacao = LerCampo(dadosRetorno, "Situação cadastral atual:");
                result.DataSituacao = LerCampo(dadosRetorno, "Data desta situação cadastral:").ToData();
                result.RegimeApuracao = LerCampo(dadosRetorno, "Data desta situação cadastral:");
                result.DataEmitenteNFe = LerCampo(dadosRetorno, "Emitente de NFe desde:").ToData();

                result.CNAE1 = LerCampo(dadosRetorno, "CNAE Fiscal:");
                var cnae = LerCampo(dadosRetorno, result.CNAE1);
                if (cnae != "CNAE Secundário:") result.CNAE1 += $" {cnae}";

                var listCnae2 = new List<string>();
                var aux = LerCampo(dadosRetorno, "CNAE Secundário:");
                if (!aux.IsEmpty()) listCnae2.Add(aux);

                do
                {
                    aux = LerCampo(dadosRetorno, aux);
                    if (aux == "Credenciado de ofício como emissor de NF-e:") break;

                    if (!aux.IsEmpty() && char.IsDigit(aux, 0))
                    {
                        listCnae2.Add(aux);
                    }
                    else
                    {
                        listCnae2[listCnae2.Count - 1] += $" {aux}";
                    }
                } while (!aux.IsEmpty());

                result.CNAE2 = listCnae2.ToArray();
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, "Erro ao processar retorno.");
            }

            return result;
        }

        private static string LerCampo(IList<string> retorno, string campo)
        {
            var ret = string.Empty;
            for (var i = 0; i < retorno.Count; i++)
            {
                var linha = retorno[i].Trim();
                if (linha != campo) continue;

                ret = retorno[i + 1].Trim().Replace("&nbsp;", string.Empty);
                retorno.RemoveAt(i);
                break;
            }

            return ret.RemoveDoubleSpaces();
        }

        #endregion Private Methods

        #endregion Methods
    }
}