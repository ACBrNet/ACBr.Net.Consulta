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
	/// Class ACBrConsultaCNPJ. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBrComponentConsulta" />
	[ToolboxBitmap(typeof(ACBrConsultaCNPJ), "ACBr.Net.Consulta.ACBrConsultaCNPJ.bmp")]
	public sealed class ACBrConsultaCNPJ : ACBrComponentConsulta
	{
		#region Field

		private const string urlBaseReceitaFederal = "http://www.receita.fazenda.gov.br/pessoajuridica/cnpj/cnpjreva/";
		private const string paginaValidacao = "valida.asp";
		private const string paginaPrincipal = "cnpjreva_solicitacao3.asp";
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
		/// Consulta o CNPJ especifico.
		/// </summary>
		/// <param name="cnpj">O CNPJ.</param>
		/// <param name="captcha">O captcha.</param>
		/// <returns>Dados da empresa.</returns>
		public ACBrEmpresa Consulta(string cnpj, string captcha = "")
		{
			Guard.Against<ACBrException>(cnpj.IsEmpty(), "Necessário informar o CNPJ.");
			Guard.Against<ACBrException>(!cnpj.IsCNPJ(), "CNPJ inválido.");

			if (captcha.IsEmpty() && OnGetCaptcha != null)
			{
				var e = new CaptchaEventArgs();
				OnGetCaptcha.Raise(this, e);

				captcha = e.Captcha;
			}

			Guard.Against<ACBrException>(captcha.IsEmpty(), "Necessário digitar o captcha.");

			var request = GetClient(urlBaseReceitaFederal + paginaValidacao);

			var postData = new Dictionary<string, string>
			{
				{"origem", "comprovante"},
				{"cnpj", cnpj.OnlyNumbers()},
				{"txtTexto_captcha_serpro_gov_br", captcha},
				{"submit1", "Consultar"},
				{"search_type", "cnpj"}
			};

			var retorno = request.SendPost(postData);

			Guard.Against<ACBrCaptchaException>(retorno.Contains("Imagem com os caracteres anti robô"), "Catpcha errado.");
			Guard.Against<ACBrException>(retorno.Contains("Erro na Consulta"), "Erro na Consulta.");
			Guard.Against<ACBrException>(retorno.Contains("Verifique se o mesmo foi digitado corretamente"), $"Não existe no Cadastro de Pessoas Jurídicas o número de CNPJ informado.{Environment.NewLine}Verifique se o mesmo foi digitado corretamente.");
			Guard.Against<ACBrException>(retorno.Contains("a. No momento não podemos atender a sua solicitação. Por favor tente mais tarde."), "Erro no site da receita federal. Tente mais tarde.");

			return ProcessResponse(retorno);
		}

		#region Private Methods

		private static ACBrEmpresa ProcessResponse(string retorno)
		{
			var result = new ACBrEmpresa();

			try
			{
				var retornoRfb = new List<string>();
				retornoRfb.AddText(retorno.StripHtml());
				retornoRfb.RemoveEmptyLines();

				result.CNPJ = LerCampo(retornoRfb, "NÚMERO DE INSCRIÇÃO");
				if (!result.CNPJ.IsEmpty()) result.TipoEmpresa = LerCampo(retornoRfb, result.CNPJ);
				result.DataAbertura = LerCampo(retornoRfb, "DATA DE ABERTURA").ToData();
				result.RazaoSocial = LerCampo(retornoRfb, "NOME EMPRESARIAL");
				result.NomeFantasia = LerCampo(retornoRfb, "TÍTULO DO ESTABELECIMENTO (NOME DE FANTASIA)");
				result.CNAE1 = LerCampo(retornoRfb, "CÓDIGO E DESCRIÇÃO DA ATIVIDADE ECONÔMICA PRINCIPAL");
				result.Logradouro = LerCampo(retornoRfb, "LOGRADOURO");
				result.Numero = LerCampo(retornoRfb, "NÚMERO");
				result.Complemento = LerCampo(retornoRfb, "COMPLEMENTO");
				result.CEP = LerCampo(retornoRfb, "CEP").FormataCEP();
				result.Bairro = LerCampo(retornoRfb, "BAIRRO/DISTRITO");
				result.Municipio = LerCampo(retornoRfb, "MUNICÍPIO");
				result.UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), LerCampo(retornoRfb, "UF").ToUpper());
				result.Situacao = LerCampo(retornoRfb, "SITUAÇÃO CADASTRAL");
				result.DataSituacao = LerCampo(retornoRfb, "DATA DA SITUAÇÃO CADASTRAL").ToData();
				result.NaturezaJuridica = LerCampo(retornoRfb, "CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA");
				result.EndEletronico = LerCampo(retornoRfb, "ENDEREÇO ELETRÔNICO");
				if (result.EndEletronico == "TELEFONE") result.EndEletronico = string.Empty;
				result.Telefone = LerCampo(retornoRfb, "TELEFONE");
				result.EFR = LerCampo(retornoRfb, "ENTE FEDERATIVO RESPONSÁVEL (EFR)");
				result.MotivoSituacao = LerCampo(retornoRfb, "MOTIVO DE SITUAÇÃO CADASTRAL");
				result.SituacaoEspecial = LerCampo(retornoRfb, "SITUAÇÃO ESPECIAL");
				result.DataSituacaoEspecial = LerCampo(retornoRfb, "DATA DA SITUAÇÃO ESPECIAL").ToData();

				var listCNAE2 = new List<string>();
				var aux = LerCampo(retornoRfb, "CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ECONÔMICAS SECUNDÁRIAS");
				if (!aux.IsEmpty()) listCNAE2.Add(aux.RemoveDoubleSpaces());

				do
				{
					aux = LerCampo(retornoRfb, aux);
					if (!aux.IsEmpty()) listCNAE2.Add(aux.RemoveDoubleSpaces());
				} while (!aux.IsEmpty());

				result.CNAE2 = listCNAE2.ToArray();
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

		#endregion Method
	}
}