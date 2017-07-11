// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : Regis Araujo
// Created          : 05-04-2017
//
// Last Modified By : RFTD
// Last Modified On : 05-08-2017
// ***********************************************************************
// <copyright file="ConsultaSintegraGO.cs" company="ACBr.Net">
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

using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ACBr.Net.Consulta.Sintegra
{
    internal class ConsultaSintegraGO : ConsultaSintegraBase<ConsultaSintegraGO>
    {
        #region Fields

        private const string URL_CONSULTA = @"http://appasp.sefaz.go.gov.br/Sintegra/Consulta/consultar.asp";

        #endregion Fields

        #region Constructors

        public ConsultaSintegraGO()
        {
            HasCaptcha = false;
        }

        #endregion Constructors

        #region Methods

        public override Image GetCaptcha()
        {
            return null;
        }

        public override ACBrEmpresa Consulta(string cnpj, string ie, string captcha)
        {
            var request = GetClient(URL_CONSULTA);

            var postData = new Dictionary<string, string>();
            if (cnpj.IsEmpty())
            {
                postData.Add("rTipoDoc", "1");
                postData.Add("tDoc", ie.Replace(",", "."));
                postData.Add("tCCE", ie.Replace(",", "."));
                postData.Add("tCNPJ", "&tCPF=&btCGC=Consultar&zion.SystemAction=consultarSintegra%28%29&zion.OnSubmited=&zion.FormElementPosted=zionFormID_1&zionPostMethod=&zionRichValidator=true");
            }
            else
            {
                postData.Add("rTipoDoc", "2");
                postData.Add("tDoc=", cnpj.Replace(",", "."));
                postData.Add("tCCE=&tCNPJ", cnpj.Replace(",", "."));
                postData.Add("tCPF", "&btCGC=Consultar&zion.SystemAction=consultarSintegra%28%29&zion.OnSubmited=&zion.FormElementPosted=zionFormID_1&zionPostMethod=&zionRichValidator=true");
            }

            var retorno = request.SendPost(postData);

            Guard.Against<ACBrException>(retorno.Contains("Nenhum resultado encontrado"), $"Não existe no Cadastro do sintegra o número de CNPJ/IE informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
            Guard.Against<ACBrException>(retorno.Contains("a. No momento não podemos atender a sua solicitação. Por favor tente mais tarde."), "Erro no site do sintegra. Tente mais tarde.");
            Guard.Against<ACBrException>(retorno.Contains("Atenção"), "Erro ao fazer a consulta");

            return ProcessResponse(retorno);
        }

        #region Private Methods

        private static List<string> GetContents(string entrada, string regex)
        {
            var padrao = Regex.Matches(entrada, regex, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return (from Match match in padrao select match.Value).ToList();
        }

        private static List<string> ProcessTableHtml(string retorno)
        {
            const string tableExpression = "<table.*?>(.*?)</table>";
            const string trPattern = "<tr(.*?)</tr>";
            const string tdPattern = "<td.*?>(.*?)</td>";
            var dadosRetorno = new List<string>();
            var tableContents = GetContents(retorno, tableExpression);
            foreach (var tableContent in tableContents)
            {
                var trContents = GetContents(tableContent, trPattern);
                foreach (var trContent in trContents)
                {
                    var tdContents = GetContents(trContent, tdPattern);
                    foreach (var item in tdContents)
                    {
                        dadosRetorno.AddText(WebUtility.HtmlDecode(item.StripHtml().Replace("&nbsp;", string.Empty)).Trim());
                        dadosRetorno.RemoveEmptyLines();
                    }
                }
            }
            return dadosRetorno;
        }

        /// <summary>
        /// Processa o retorno html e retorno o objeto tipo ACBrEmpresa com dados
        /// </summary>
        /// <param name="retorno"></param>
        /// <returns>objeto tipo ACBrEmpresa</returns>
        private static ACBrEmpresa ProcessResponse(string retorno)
        {
            var result = new ACBrEmpresa();
            var dadosRetorno = ProcessTableHtml(retorno);
            try
            {
                result.CNPJ = LerCampo(dadosRetorno, "CNPJ:");
                result.InscricaoEstadual = LerCampo(dadosRetorno, "Inscrição Estadual - CCE :");
                result.RazaoSocial = LerCampo(dadosRetorno, "Nome Empresarial:");
                result.Logradouro = LerCampo(dadosRetorno, "Logradouro:");
                result.Numero = LerCampo(dadosRetorno, "Número:");
                result.Complemento = LerCampo(dadosRetorno, "Complemento:");

                var dadosRetorno2 = new List<string>();
                dadosRetorno2.AddText(WebUtility.HtmlDecode(retorno.StripHtml().Replace("&nbsp;", Environment.NewLine)).Trim());
                dadosRetorno2.RemoveEmptyLines();
                result.Bairro = LerCampo(dadosRetorno2, "Bairro:");
                dadosRetorno2 = null;

                result.Municipio = LerCampo(dadosRetorno, "Município:");
                result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(dadosRetorno, "UF:").ToUpper());
                result.CEP = LerCampo(dadosRetorno, "CEP:").FormataCEP();
                result.Telefone = LerCampo(dadosRetorno, "Telefone:");
                result.AtividadeEconomica = LerCampo(dadosRetorno, "Atividade Principal");
                result.DataAbertura = LerCampo(dadosRetorno, "Data de Cadastramento:").ToData();
                result.Situacao = LerCampo(dadosRetorno, "Situação Cadastral Vigente:");
                result.DataSituacao = LerCampo(dadosRetorno, "Data desta Situação Cadastral:").ToData();
                result.RegimeApuracao = LerCampo(dadosRetorno, "Regime de Apuração:");
                result.DataEmitenteNFe = LerCampo(dadosRetorno, "Emitente de NFe desde:").ToData();
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
            var log = string.Empty;
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