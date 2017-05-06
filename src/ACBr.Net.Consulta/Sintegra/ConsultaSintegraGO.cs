// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : Regis Araujo
// Created          : 04-maio-2017
//
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
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ACBr.Net.Consulta.Sintegra
{
    internal class ConsultaSintegraGO : ConsultaSintegraBase<ConsultaSintegraGO>
    {
        #region Fields

        private const string URL_BASE = @"http://appasp.sefaz.go.gov.br/Sintegra/Consulta/default.asp";
        private const string URL_CAPTCHA = @"http://appasp.sefaz.go.gov.br/Sintegra/Consulta/default.asp";
        private const string URL_CONSULTA = @"http://appasp.sefaz.go.gov.br/Sintegra/Consulta/consultar.asp";

        #endregion Fields

        #region Methods

        public override Image GetCaptcha()
        {
            return null;
        }

        
        public override ACBrEmpresa Consulta(string cnpj, string ie, string captcha)
        {
            //rTipoDoc=2&tDoc=19.529.644%2F0001-08&tCCE=&tCNPJ=19.529.644%2F0001-08&tCPF=&btCGC=Consultar&zion.SystemAction=consultarSintegra%28%29&zion.OnSubmited=&zion.FormElementPosted=zionFormID_1&zionPostMethod=&zionRichValidator=true
            //rTipoDoc=1&tDoc=10.588.548-7&tCCE=10.588.548-7&tCNPJ=&tCPF=&btCGC=Consultar&zion.SystemAction=consultarSintegra%28%29&zion.OnSubmited=&zion.FormElementPosted=zionFormID_1&zionPostMethod=&zionRichValidator=true
            var request = GetClient(URL_CONSULTA);
            request.Method = "POST";
            var postData = new StringBuilder();
            if (cnpj.IsEmpty())
            {
                postData.Append("rTipoDoc=1");
                postData.Append("&tDoc=" + ie.Replace(",", "."));
                postData.Append("&tCCE=" + ie.Replace(",", "."));
                postData.Append("&tCNPJ=&tCPF=&btCGC=Consultar&zion.SystemAction=consultarSintegra%28%29&zion.OnSubmited=&zion.FormElementPosted=zionFormID_1&zionPostMethod=&zionRichValidator=true");
            }
            else
            {
                postData.Append("rTipoDoc=2"); 
                postData.Append("&tDoc=" + cnpj.Replace(",", "."));
                postData.Append("&tCCE=&tCNPJ=" + cnpj.Replace(",", "."));
                postData.Append("&tCPF=&btCGC=Consultar&zion.SystemAction=consultarSintegra%28%29&zion.OnSubmited=&zion.FormElementPosted=zionFormID_1&zionPostMethod=&zionRichValidator=true");
                                
            }
            
            var byteArray = Encoding.GetEncoding("ISO-8859-1").GetBytes(postData.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var retorno = GetHtmlResponse(request.GetResponse());

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
                dadosRetorno.AddText(WebUtility.HtmlDecode(retorno.StripHtml().Replace("&nbsp;", Environment.NewLine)));
                dadosRetorno.RemoveEmptyLines();

                result.CNPJ = LerCampo(dadosRetorno, "CNPJ:");
                result.InscricaoEstadual = LerCampo(dadosRetorno, "Inscrição Estadual - CCE :");
                result.RazaoSocial = LerCampo(dadosRetorno, "Nome Empresarial:");
                result.Logradouro = LerCampo(dadosRetorno, "Logradouro:");
                result.Numero = LerCampo(dadosRetorno, "Número:");
                result.Complemento = LerCampo(dadosRetorno, "Complemento:");
                result.Bairro = LerCampo(dadosRetorno, "Bairro:");
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

                if (campo == "Logradouro:")
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

        #endregion Private Methods

        #endregion Methods
    }
}
