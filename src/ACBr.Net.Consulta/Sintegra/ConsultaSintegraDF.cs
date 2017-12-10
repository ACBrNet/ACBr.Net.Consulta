// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : Regis Araujo
// Created          : 05-04-2017
//
// Last Modified By : RFTD
// Last Modified On : 05-08-2017
// ***********************************************************************
// <copyright file="ConsultaSintegraDF.cs" company="ACBr.Net">
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
    internal class ConsultaSintegraDF : ConsultaSintegraBase<ConsultaSintegraDF>
    {
        #region Fields

        private const string URL_CONSULTA = @"http://www.fazenda.df.gov.br/aplicacoes/sintegra/consulta.cfm";
        private const string URL_CONSULTA_DET = @"http://www.fazenda.df.gov.br/aplicacoes/sintegra/detalhamento.cfm";
        private const string URL_REFERER1 = @"http://www.fazenda.df.gov.br/area.cfm?id_area=110";

        #endregion Fields

        #region Constructors

        public ConsultaSintegraDF()
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
            request.Referer = URL_REFERER1;

            var postData = new Dictionary<string, string>
            {
                { "sefp", "1" },
                { "estado", "DF" }
            };
            if (cnpj.IsEmpty())
            {
                postData.Add("identificador", "3");
                postData.Add("argumento", ie);
            }
            else
            {
                postData.Add("identificador", "2");
                postData.Add("argumento", cnpj);
            }

            var retorno = request.SendPost(postData, Encoding.UTF8);
            var dadosRetorno = new List<string>();
            dadosRetorno.AddText(WebUtility.HtmlDecode(retorno.StripHtml().Replace("&nbsp;", Environment.NewLine)));
            dadosRetorno.RemoveEmptyLines();

            var cfdf = LerCampo(dadosRetorno, "SITUAÇÃO");
            if (cfdf != string.Empty)
            {
                request = GetClient(URL_CONSULTA_DET);
                request.Referer = URL_CONSULTA;

                postData.Clear();
                postData.Add("cCFDF", cfdf);
                retorno = request.SendPost(postData, Encoding.UTF8);
            }

            Guard.Against<ACBrException>(retorno.Contains("Nenhum resultado encontrado"), $"Não existe no Cadastro do sintegra o número de CNPJ/IE informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
            Guard.Against<ACBrException>(retorno.Contains("a. No momento não podemos atender a sua solicitação. Por favor tente mais tarde."), "Erro no site do sintegra. Tente mais tarde.");
            Guard.Against<ACBrException>(retorno.Contains("Atenção"), "Erro ao fazer a consulta");

            return ProcessResponse(retorno);
        }

        #region Private Methods

        /// <summary>
        /// Processa o retorno html e retorno o objeto tipo ACBrEmpresa com dados
        /// </summary>
        /// <param name="retorno"></param>
        /// <returns>objeto tipo ACBrEmpresa</returns>
        private static ACBrEmpresa ProcessResponse(string retorno)
        {
            const string tableExpression = "<table.*?>(.*?)</table>";
            const string trPattern = "<tr(.*?)</tr>";
            const string tdPattern = "<td.*?>(.*?)</td>";

            var result = new ACBrEmpresa();
            try
            {
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
                            dadosRetorno.AddText((Regex.Replace(item, "<.*?>", string.Empty).Trim()));
                        }
                    }
                }
                result.CNPJ = LerCampo(dadosRetorno, "CNPJ/CPF");
                result.InscricaoEstadual = LerCampo(dadosRetorno, "CF/DF");
                result.RazaoSocial = LerCampo(dadosRetorno, "RAZÃO SOCIAL");
                result.Logradouro = LerCampo(dadosRetorno, "LOGRADOURO");
                result.Numero = LerCampo(dadosRetorno, "Número:");
                result.Complemento = LerCampo(dadosRetorno, "Complemento:");
                result.Bairro = LerCampo(dadosRetorno, "BAIRRO");
                result.Municipio = LerCampo(dadosRetorno, "MUNICÍPIO");
                result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(dadosRetorno, "UF").ToUpper());
                result.CEP = LerCampo(dadosRetorno, "CEP").FormataCEP();
                result.Telefone = LerCampo(dadosRetorno, "Telefone");
                result.AtividadeEconomica = LerCampo(dadosRetorno, "ATIVIDADE PRINCIPAL");
                result.DataAbertura = LerCampo(dadosRetorno, "DATA DESSA SITUAÇÃO CADASTRAL").ToData();
                result.Situacao = LerCampo(dadosRetorno, "SITUAÇÃO CADASTRAL");
                result.DataSituacao = LerCampo(dadosRetorno, "DATA DESSA SITUAÇÃO CADASTRAL").ToData();
                result.RegimeApuracao = LerCampo(dadosRetorno, "REGIME DE APURAÇÃO");
                result.DataEmitenteNFe = LerCampo(dadosRetorno, "Emitente de NFe desde:").ToData();
            }
            catch (Exception exception)
            {
                throw new ACBrException(exception, "Erro ao processar retorno.");
            }

            return result;
        }

        /// <summary>
        /// Efetua a pesquisa na Lista de Retorno
        /// </summary>
        /// <param name="retorno">Lista a ser Pesquisa tipo Ilist</param>
        /// <param name="campo">String a ser pesquisada.</param>
        /// <returns></returns>
        private static string LerCampo(IList<string> retorno, string campo)
        {
            var ret = string.Empty;
            var log = string.Empty;
            for (var i = 0; i < retorno.Count; i++)
            {
                var linha = retorno[i].Trim();
                if (linha != campo) continue;

                if (campo == "ATIVIDADE PRINCIPAL")
                {
                    ret = retorno[i + 1].Trim().Replace("&nbsp;", string.Empty);
                    log = retorno[i + 2].Trim().Replace("&nbsp;", string.Empty);
                    ret = ret + " " + log;
                    break;
                }
                ret = retorno[i + 1].Trim().Replace("&nbsp;", string.Empty);
                retorno.RemoveAt(i);
                break;
            }

            return ret;
        }

        private static List<string> GetContents(string input, string pattern)

        {
            var matches = Regex.Matches(input, pattern, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return (from Match match in matches select match.Value).ToList();
        }

        #endregion Private Methods

        #endregion Methods
    }
}