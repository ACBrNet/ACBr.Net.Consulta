// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-20-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-20-2017
// ***********************************************************************
// <copyright file="ConsultaSintegraSP.cs" company="ACBr.Net">
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
using System.Net;
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.Sintegra
{
	internal class ConsultaSintegraSP : ConsultaSintegraBase<ConsultaSintegraSP>
	{
		#region Fields

		private const string URL_BASE = @"http://pfeserv1.fazenda.sp.gov.br/sintegrapfe/consultaSintegraServlet";
		private const string URL_CAPTCHA = @"http://pfeserv1.fazenda.sp.gov.br/sintegrapfe/imageGenerator?";
		private const string URL_CONSULTA = @"http://pfeserv1.fazenda.sp.gov.br/sintegrapfe/sintegra";

		#endregion Fields

		#region Methods

		public override Image GetCaptcha()
		{
			var request = GetClient(URL_BASE);
			var response = request.GetResponse();

			string htmlResult;
			using (var reader = new StreamReader(response.GetResponseStream()))
				htmlResult = reader.ReadToEnd();

			if (htmlResult.Length < 1) return null;

			urlParams.Clear();
			urlParams.Add("hidFlag", htmlResult.GetStrBetween("name=\"hidFlag\" value=\"", "\""));
			urlParams.Add("paramBot", htmlResult.GetStrBetween("name=\"paramBot\" value=\"", "\""));
			var imageKey = htmlResult.GetStrBetween("src=\"/sintegrapfe/imageGenerator?", "\"").Replace("amp;", string.Empty);
			request = GetClient(URL_CAPTCHA + imageKey);
			response = request.GetResponse();

			var captchaStream = response.GetResponseStream();
			Guard.Against<ACBrCaptchaException>(captchaStream == null, "Erro ao carregar captcha");

			return Image.FromStream(captchaStream);
		}

		public override ACBrEmpresa Consulta(string cnpj, string ie, string captcha)
		{
			var request = GetClient(URL_CONSULTA);
			request.Method = "POST";

			var postData = new StringBuilder();

			foreach (var param in urlParams)
			{
				postData.AppendFormat("{0}={1}&", param.Key, param.Value);
			}

			if (cnpj.IsEmpty())
			{
				postData.Append("servico=ie&");
				postData.AppendFormat("Key={0}&", captcha);
				postData.Append("cnpj=&");
				postData.AppendFormat("ie={0}&", ie.IsEmpty() ? string.Empty : ie.OnlyNumbers());
				postData.Append("botao=Consulta+por+IE");
			}
			else
			{
				postData.Append("servico=cnpj&");
				postData.AppendFormat("Key={0}&", captcha);
				postData.AppendFormat("cnpj={0}&", cnpj.IsEmpty() ? string.Empty : cnpj.OnlyNumbers());
				postData.Append("botao=Consulta+por+CNPJ&ie=");
			}

			var byteArray = Encoding.GetEncoding("ISO-8859-1").GetBytes(postData.ToString());
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = byteArray.Length;

			var dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();

			var retorno = GetHtmlResponse(request.GetResponse());

			Guard.Against<ACBrCaptchaException>(retorno.Contains("O valor da imagem esta incorreto ou expirou"), "O Texto digitado não confere com a Imagem.");
			Guard.Against<ACBrException>(retorno.Contains("Nenhum resultado encontrado"), $"Não existe no Cadastro do sintegra o número de CNPJ/IE informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
			Guard.Against<ACBrException>(retorno.Contains("Serviço indisponível!"), "Site do sintegra indisponível. Tente mais tarde.");
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
				result.InscricaoEstadual = LerCampo(dadosRetorno, "Inscrição Estadual:");
				result.RazaoSocial = LerCampo(dadosRetorno, "Razão Social:");
				result.Logradouro = LerCampo(dadosRetorno, "Logradouro:");
				result.Numero = LerCampo(dadosRetorno, "Número:");
				result.Complemento = LerCampo(dadosRetorno, "Complemento:");
				result.Bairro = LerCampo(dadosRetorno, "Bairro:");
				result.Municipio = LerCampo(dadosRetorno, "Município:");
				result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(dadosRetorno, "UF:").ToUpper());
				result.CEP = LerCampo(dadosRetorno, "CEP:").FormataCEP();

				result.Telefone = LerCampo(dadosRetorno, "Telefone:");
				result.AtividadeEconomica = LerCampo(dadosRetorno, "Atividade Econômica:");
				result.DataAbertura = LerCampo(dadosRetorno, "Data de Inicio de Atividade:").ToData();
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