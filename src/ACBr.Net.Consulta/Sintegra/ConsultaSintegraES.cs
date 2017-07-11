// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 05-26-2017
//
// Last Modified By : RFTD
// Last Modified On : 05-26-2017
// ***********************************************************************
// <copyright file="ConsultaSintegraES.cs" company="ACBr.Net">
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
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.Sintegra
{
    internal class ConsultaSintegraES : ConsultaSintegraBase<ConsultaSintegraES>
    {
        #region Fields

        private const string URL_CONSULTA = @"http://www.sintegra.es.gov.br/resultado.php";

        #endregion Fields

        #region Constructors

        public ConsultaSintegraES()
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

            var postData = new Dictionary<string, string>
            {
                { "num_cnpj", cnpj.OnlyNumbers() },
                { "num_ie", ie.OnlyNumbers() },
                { "botao", "Consulta" }
            };
            var retorno = request.SendPost(postData);

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
            var result = new ACBrEmpresa();
            var dadosRetorno = new List<string>();
            dadosRetorno.AddText(retorno.StripHtml());
            dadosRetorno.RemoveEmptyLines();
            try
            {
                result.CNPJ = LerCampo(dadosRetorno, "CNPJ:");
                result.InscricaoEstadual = LerCampo(dadosRetorno, "Inscrição Estadual:");
                result.RazaoSocial = LerCampo(dadosRetorno, "Razão Social :");
                result.Logradouro = LerCampo(dadosRetorno, "Logradouro:");
                result.Numero = LerCampo(dadosRetorno, "Número:");
                result.Complemento = LerCampo(dadosRetorno, "Complemento:");
                result.Municipio = LerCampo(dadosRetorno, "Município:");
                result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(dadosRetorno, "UF:").ToUpper());
                result.CEP = LerCampo(dadosRetorno, "CEP:").FormataCEP();
                result.Telefone = LerCampo(dadosRetorno, "Telefone:");
                result.AtividadeEconomica = LerCampo(dadosRetorno, "Atividade Econômica:");
                result.DataInicioAtividade = LerCampo(dadosRetorno, "Data de Inicio de Atividade:").ToData();
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