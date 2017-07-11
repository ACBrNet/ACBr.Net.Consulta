// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-16-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ACBrConsultaCPF.cs" company="ACBr.Net">
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

namespace ACBr.Net.Consulta.Receita
{
    /// <summary>
    /// Class ACBrConsultaCPF. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="ACBrComponentConsulta" />
    [ToolboxBitmap(typeof(ACBrConsultaCPF), "ACBr.Net.Consulta.ACBrConsultaCPF.bmp")]
    // ReSharper disable once InconsistentNaming
    public sealed class ACBrConsultaCPF : ACBrComponentConsulta
    {
        #region Field

        private const string urlBaseReceitaFederal = "https://www.receita.fazenda.gov.br/Aplicacoes/SSL/ATCTA/CPF/";
        private const string paginaValidacao = "ConsultaSituacao/ConsultaPublicaExibir.asp";
        private const string paginaPrincipal = "ConsultaSituacao/ConsultaPublica.asp";
        private const string paginaCaptcha = "captcha/gerarCaptcha.asp";

        #endregion Field

        #region Events

        /// <summary>
        /// Evento disparado se a consultar for chamada com o captcha vazio.
        /// </summary>
        public event EventHandler<CaptchaEventArgs> OnGetCaptcha;

        #endregion Events

        #region Method

        /// <summary>
        /// Retorna a imagem do Captcha para fazer a consulta.
        /// </summary>
        /// <returns>Imagem Captcha.</returns>
        public Image GetCaptcha()
        {
            var request = GetClient(urlBaseReceitaFederal + paginaPrincipal);
            var response = request.GetResponse();

            string htmlResult;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                htmlResult = reader.ReadToEnd();
            }

            if (htmlResult.Length < 1) return null;

            request = GetClient(urlBaseReceitaFederal + paginaCaptcha);
            response = request.GetResponse();

            var captchaStream = response.GetResponseStream();
            Guard.Against<ACBrCaptchaException>(captchaStream.IsNull(), "Erro ao carregar captcha");

            return Image.FromStream(captchaStream);
        }

        /// <summary>
        /// Consulta o CPF especifico.
        /// </summary>
        /// <param name="cpf">O CPF.</param>
        /// <param name="dataNascimento">A Data de Nascimento.</param>
        /// <param name="captcha">O captcha.</param>
        /// <returns>Dados da pessoa.</returns>
        public ACBrPessoa Consulta(string cpf, DateTime dataNascimento, string captcha = "")
        {
            Guard.Against<ACBrException>(cpf.IsEmpty(), "Necessário informar o CPF.");
            Guard.Against<ACBrException>(dataNascimento == DateTime.MinValue, "Necessário informar a data de nascimento.");
            Guard.Against<ACBrException>(!cpf.IsCPF(), "CPF inválido.");

            if (captcha.IsEmpty() && OnGetCaptcha != null)
            {
                var e = new CaptchaEventArgs();
                OnGetCaptcha.Raise(this, e);

                captcha = e.Captcha;
            }

            Guard.Against<ACBrException>(captcha.IsEmpty(), "Necessário digitar o captcha.");

            var request = GetClient(urlBaseReceitaFederal + paginaValidacao);

            var postData = new Dictionary<string, string>();
            postData.Add("tempTxtCPF", cpf.FormataCPF());
            postData.Add("tempTxtNascimento", dataNascimento.ToShortDateString());
            postData.Add("temptxtToken_captcha_serpro_gov_br", "");
            postData.Add("txtTexto_captcha_serpro_gov_br", captcha);
            postData.Add("temptxtTexto_captcha_serpro_gov_br", captcha);
            postData.Add("Enviar", "Consultar");

            var retorno = request.SendPost(postData);

            Guard.Against<ACBrCaptchaException>(retorno.Contains("Os caracteres da imagem não foram preenchidos corretamente"), "Os caracteres da imagem não foram preenchidos corretamente.");
            Guard.Against<ACBrException>(retorno.Contains("O número do CPF não é válido."), "EO número do CPF não é válido. Verifique se o mesmo foi digitado corretamente.");
            Guard.Against<ACBrException>(retorno.Contains("Não existe no Cadastro de Pessoas Jurídicas o número de CPF informado."), $"Não existe no Cadastro de Pessoas Jurídicas o número de CPF informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
            Guard.Against<ACBrException>(retorno.Contains("a. No momento não podemos atender a sua solicitação. Por favor tente mais tarde."), "Erro no site da receita federal. Tente mais tarde.");

            return new ACBrPessoa(retorno);
        }

        #endregion Method
    }
}