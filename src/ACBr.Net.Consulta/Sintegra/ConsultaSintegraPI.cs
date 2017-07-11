// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-20-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-20-2017
// ***********************************************************************
// <copyright file="ConsultaSintegraPI.cs" company="ACBr.Net">
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
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.Sintegra
{
    internal class ConsultaSintegraPI : ConsultaSintegraBase<ConsultaSintegraPI>
    {
        #region Fields

        private const string URL_BASE = @"http://webas.sefaz.pi.gov.br/SintegraConsultaPublica/";
        private const string URL_CAPTCHA = @"http://webas.sefaz.pi.gov.br/SintegraConsultaPublica/views/index.jsf?primefacesDynamicContent=securityCaptcha.problem&primefaces_image=";
        private const string URL_CONSULTA = @"http://webas.sefaz.pi.gov.br/SintegraConsultaPublica/index.jsf";

        #endregion Fields

        #region Methods

        public override Image GetCaptcha()
        {
            var request = GetClient(URL_BASE);
            var response = request.GetResponse();

            string htmlResult;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                htmlResult = reader.ReadToEnd();
            }

            if (htmlResult.Length < 1) return null;

            var url = $"{URL_CAPTCHA}{htmlResult.GetStrBetween("primefaces_image=", "\"")}";
            request = GetClient(url);
            response = request.GetResponse();

            var captchaStream = response.GetResponseStream();
            Guard.Against<ACBrCaptchaException>(captchaStream.IsNull(), "Erro ao carregar captcha");

            return Image.FromStream(captchaStream);
        }

        public override ACBrEmpresa Consulta(string cnpj, string ie, string captcha)
        {
            var request = GetClient(URL_CONSULTA);

            var postData = new Dictionary<string, string>
            {
                { "cnpj", cnpj.IsEmpty() ? string.Empty : cnpj.FormataCNPJ() },
                { "ie", ie.IsEmpty() ? string.Empty : ie.FormatarIE("MS") },
                { "captcha", captcha }
            };
            var retorno = request.SendPost(postData, Encoding.UTF8);

            Guard.Against<ACBrCaptchaException>(retorno.Contains("O Texto digitado não confere com a Imagem"), "O Texto digitado não confere com a Imagem.");
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
                dadosRetorno.AddText(retorno.StripHtml());
                dadosRetorno.RemoveEmptyLines();

                result.InscricaoEstadual = LerCampo(dadosRetorno, "Inscrição Estadual");
                result.DataAbertura = LerCampo(dadosRetorno, "Data de Início da Atividade").ToData();
                result.CNPJ = LerCampo(dadosRetorno, "CNPJ");
                result.RazaoSocial = LerCampo(dadosRetorno, "Razão Social/Nome");
                result.Logradouro = LerCampo(dadosRetorno, "Logradouro");
                result.Numero = LerCampo(dadosRetorno, "Numero");
                result.Complemento = LerCampo(dadosRetorno, "Complemento");
                result.CEP = LerCampo(dadosRetorno, "CEP").FormataCEP();
                result.Bairro = LerCampo(dadosRetorno, "Bairro");
                result.Municipio = LerCampo(dadosRetorno, "Município");
                result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(dadosRetorno, "UF").ToUpper());
                result.Situacao = LerCampo(dadosRetorno, "Situação Cadastral");
                result.DataSituacao = LerCampo(dadosRetorno, "Data da Última Atualização").ToData();
                result.MotivoSituacao = LerCampo(dadosRetorno, "Motivo da Situação");
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

            return ret;
        }

        #endregion Private Methods

        #endregion Methods
    }
}