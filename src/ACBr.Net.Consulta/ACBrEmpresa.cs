// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-16-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ACBrEmpresa.cs" company="ACBr.Net">
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
using ACBr.Net.Core;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta
{
	/// <summary>
	/// Classe ACBrEmpresa. Esta classe não pode ser herdada.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	public sealed class ACBrEmpresa
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ACBrEmpresa"/> class.
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		internal ACBrEmpresa(string retorno)
		{
			ProcessResponse(retorno);
		}

		#endregion Constructors

		#region Propertys

		/// <summary>
		/// Retorna o CNPJ.
		/// </summary>
		/// <value>O CNPJ.</value>
		public string CNPJ { get; private set; }

		/// <summary>
		/// Retorna o tipo empresa.
		/// </summary>
		/// <value>O tipo empresa.</value>
		public string TipoEmpresa { get; private set; }

		/// <summary>
		/// Retorna a data abertura.
		/// </summary>
		/// <value>A data abertura.</value>
		public DateTime DataAbertura { get; private set; }

		/// <summary>
		/// Retorna a razao social.
		/// </summary>
		/// <value>The razao social.</value>
		public string RazaoSocial { get; private set; }

		/// <summary>
		/// Retorna o Nome Fantasia.
		/// </summary>
		/// <value>The nomefantasia.</value>
		public string NomeFantasia { get; private set; }

		/// <summary>
		/// Retorna o cna e1.
		/// </summary>
		/// <value>The cna e1.</value>
		public string CNAE1 { get; private set; }

		/// <summary>
		/// Retorna o logradouro.
		/// </summary>
		/// <value>The logradouro.</value>
		public string Logradouro { get; private set; }

		/// <summary>
		/// Retorna o numero.
		/// </summary>
		/// <value>The numero.</value>
		public string Numero { get; private set; }

		/// <summary>
		/// Retorna o complemento.
		/// </summary>
		/// <value>The complemento.</value>
		public string Complemento { get; private set; }

		/// <summary>
		/// Retorna o cep.
		/// </summary>
		/// <value>The cep.</value>
		public string CEP { get; private set; }

		/// <summary>
		/// Retorna o bairro.
		/// </summary>
		/// <value>The bairro.</value>
		public string Bairro { get; private set; }

		/// <summary>
		/// Retorna o municipio.
		/// </summary>
		/// <value>The municipio.</value>
		public string Municipio { get; private set; }

		/// <summary>
		/// Retorna o uf.
		/// </summary>
		/// <value>The uf.</value>
		public string UF { get; private set; }

		/// <summary>
		/// Retorna o situacao.
		/// </summary>
		/// <value>The situacao.</value>
		public string Situacao { get; private set; }

		/// <summary>
		/// Retorna o data situacao.
		/// </summary>
		/// <value>The data situacao.</value>
		public DateTime DataSituacao { get; private set; }

		/// <summary>
		/// Retorna o natureza juridica.
		/// </summary>
		/// <value>The natureza juridica.</value>
		public string NaturezaJuridica { get; private set; }

		/// <summary>
		/// Retorna o end eletronico.
		/// </summary>
		/// <value>The end eletronico.</value>
		public string EndEletronico { get; private set; }

		/// <summary>
		/// Retorna o telefone.
		/// </summary>
		/// <value>The telefone.</value>
		public string Telefone { get; private set; }

		/// <summary>
		/// Retorna o ENTE FEDERATIVO RESPONSÁVEL (EFR).
		/// </summary>
		/// <value>The efr.</value>
		public string EFR { get; private set; }

		/// <summary>
		/// Retorna o motivo situacao.
		/// </summary>
		/// <value>The motivo situacao.</value>
		public string MotivoSituacao { get; private set; }

		/// <summary>
		/// Retorna o cna e2.
		/// </summary>
		/// <value>The cna e2.</value>
		public string[] CNAE2 { get; private set; }

		/// <summary>
		/// Retorna o situacao especial.
		/// </summary>
		/// <value>The situacao especial.</value>
		public string SituacaoEspecial { get; private set; }

		/// <summary>
		/// Retorna o data situacao especial.
		/// </summary>
		/// <value>The data situacao especial.</value>
		public DateTime DataSituacaoEspecial { get; private set; }

		#endregion Propertys

		#region Methods

		/// <summary>
		/// Processa a resposta do site da Receita Federal
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		/// <exception cref="ACBrException">Erro ao processar retorno.</exception>
		private void ProcessResponse(string retorno)
		{
			try
			{
				var retornoRfb = new List<string>();
				retornoRfb.AddText(ConsultaHelpers.StripHtml(retorno));
				ConsultaHelpers.RemoveEmptyLines(retornoRfb);

				CNPJ = LerCampo(retornoRfb, "NÚMERO DE INSCRIÇÃO");
				if (!CNPJ.IsEmpty()) TipoEmpresa = LerCampo(retornoRfb, CNPJ);
				DataAbertura = LerCampo(retornoRfb, "DATA DE ABERTURA").ToData();
				RazaoSocial = LerCampo(retornoRfb, "NOME EMPRESARIAL");
				NomeFantasia = LerCampo(retornoRfb, "TÍTULO DO ESTABELECIMENTO (NOME DE FANTASIA)");
				CNAE1 = LerCampo(retornoRfb, "CÓDIGO E DESCRIÇÃO DA ATIVIDADE ECONÔMICA PRINCIPAL");
				Logradouro = LerCampo(retornoRfb, "LOGRADOURO");
				Numero = LerCampo(retornoRfb, "NÚMERO");
				Complemento = LerCampo(retornoRfb, "COMPLEMENTO");
				CEP = LerCampo(retornoRfb, "CEP").FormataCEP();
				Bairro = LerCampo(retornoRfb, "BAIRRO/DISTRITO");
				Municipio = LerCampo(retornoRfb, "MUNICÍPIO");
				UF = LerCampo(retornoRfb, "UF");
				Situacao = LerCampo(retornoRfb, "SITUAÇÃO CADASTRAL");
				DataSituacao = LerCampo(retornoRfb, "DATA DA SITUAÇÃO CADASTRAL").ToData();
				NaturezaJuridica = LerCampo(retornoRfb, "CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA");
				EndEletronico = LerCampo(retornoRfb, "ENDEREÇO ELETRÔNICO");
				if (EndEletronico == "TELEFONE") EndEletronico = string.Empty;
				Telefone = LerCampo(retornoRfb, "TELEFONE");
				EFR = LerCampo(retornoRfb, "ENTE FEDERATIVO RESPONSÁVEL (EFR)");
				MotivoSituacao = LerCampo(retornoRfb, "MOTIVO DE SITUAÇÃO CADASTRAL");
				SituacaoEspecial = LerCampo(retornoRfb, "SITUAÇÃO ESPECIAL");
				DataSituacaoEspecial = LerCampo(retornoRfb, "DATA DA SITUAÇÃO ESPECIAL").ToData();

				var listCNAE2 = new List<string>();
				var aux = LerCampo(retornoRfb, "CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ECONÔMICAS SECUNDÁRIAS");
				if (!aux.IsEmpty()) listCNAE2.Add(ConsultaHelpers.RemoveDoubleSpaces(aux));

				do
				{
					aux = LerCampo(retornoRfb, aux);
					if (!aux.IsEmpty()) listCNAE2.Add(ConsultaHelpers.RemoveDoubleSpaces(aux));
				} while (!aux.IsEmpty());

				CNAE2 = listCNAE2.ToArray();
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, "Erro ao processar retorno.");
			}
		}

		public static string LerCampo(IList<string> retorno, string campo)
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

		#endregion Methods
	}
}