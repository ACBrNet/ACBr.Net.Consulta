// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-16-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ACBrConsultaCNPJ.cs" company="ACBr.Net">
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
using System.Drawing;
using System.IO;
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta
{
	[ToolboxBitmap(typeof(ACBrConsultaCNPJ), "ACBrConsultaCNPJ")]
	public sealed class ACBrConsultaCNPJ : ACBrConsultaBase
	{
		#region Field

		private const string urlBaseReceitaFederal = "http://www.receita.fazenda.gov.br/pessoajuridica/cnpj/cnpjreva/";
		private const string paginaValidacao = "valida.asp";
		private const string paginaPrincipal = "cnpjreva_solicitacao2.asp";
		private const string paginaCaptcha = "captcha/gerarCaptcha.asp";

		#endregion Field

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

			return Image.FromStream(response.GetResponseStream());
		}

		/// <summary>
		/// Consulta o CNPJ especifico.
		/// </summary>
		/// <param name="cnpj">O CNPJ.</param>
		/// <param name="captcha">O captcha.</param>
		/// <returns>Dados da empresa.</returns>
		public ACBrEmpresa Consulta(string cnpj, string captcha)
		{
			Guard.Against<ACBrException>(cnpj.IsEmpty(), "É necessário digitar o CNPJ.");
			Guard.Against<ACBrException>(captcha.IsEmpty(), "É necessário digitar o captcha.");

			var request = GetClient(urlBaseReceitaFederal + paginaValidacao);
			request.Method = "POST";

			var postData = new StringBuilder();
			postData.Append("origem=comprovante&");
			postData.AppendFormat("cnpj={0}&", cnpj.OnlyNumbers());
			postData.AppendFormat("txtTexto_captcha_serpro_gov_br={0}&", captcha);
			postData.Append("submit1=Consultar&");
			postData.Append("search_type=cnpj");

			var byteArray = Encoding.UTF8.GetBytes(postData.ToString());
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = byteArray.Length;

			var dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();

			var response = request.GetResponse();
			Guard.Against<ACBrException>(response.IsNull(), "Erro ao acessar o site da Receita Federal.");

			// ReSharper disable once AssignNullToNotNullAttribute
			var stHtml = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
			var retorno = stHtml.ReadToEnd();

			Guard.Against<ACBrException>(retorno.Contains("Imagem com os caracteres anti robô"), "Catpcha errado.");
			Guard.Against<ACBrException>(retorno.Contains("Erro na Consulta"), "Erro na Consulta.");
			Guard.Against<ACBrException>(retorno.Contains("Verifique se o mesmo foi digitado corretamente"), $"Não existe no Cadastro de Pessoas Jurídicas o número de CNPJ informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
			Guard.Against<ACBrException>(retorno.Contains("a. No momento não podemos atender a sua solicitação. Por favor tente mais tarde."), "Erro no site da receita federal. Tente mais tarde.");

			return new ACBrEmpresa(retorno);
		}

		#endregion Method
	}
}