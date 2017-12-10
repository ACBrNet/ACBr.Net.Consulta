// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-16-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-16-2017
// ***********************************************************************
// <copyright file="ACBrPessoa.cs" company="ACBr.Net">
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
using System.Web;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta
{
	public sealed class ACBrPessoa
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ACBrEmpresa"/> class.
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		internal ACBrPessoa(string retorno)
		{
			ProcessResponse(retorno);
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Retorna o CPF.
		/// </summary>
		/// <value>O CNPJ.</value>
		public string CPF { get; private set; }

		/// <summary>
		/// Gets the data nascimento.
		/// </summary>
		/// <value>The data nascimento.</value>
		public DateTime DataNascimento { get; private set; }

		/// <summary>
		/// Gets the data situacao.
		/// </summary>
		/// <value>The data situacao.</value>
		public DateTime DataInscricao { get; private set; }

		/// <summary>
		/// Gets the nome.
		/// </summary>
		/// <value>The nome.</value>
		public string Nome { get; private set; }

		/// <summary>
		/// Gets the situacao.
		/// </summary>
		/// <value>The situacao.</value>
		public string Situacao { get; private set; }

		/// <summary>
		/// Gets the digito verificador.
		/// </summary>
		/// <value>The digito verificador.</value>
		public string DigitoVerificador { get; private set; }

		/// <summary>
		/// Gets the emissao.
		/// </summary>
		/// <value>The emissao.</value>
		public string Emissao { get; private set; }

		/// <summary>
		/// Gets the cod control controle.
		/// </summary>
		/// <value>The cod control controle.</value>
		public string CodCtrlControle { get; private set; }

		#endregion Properties

		#region Methods

		/// <summary>
		/// Processa a resposta do site da Receita Federal
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		/// <exception cref="ACBrException">Erro ao processar retorno.</exception>
		private void ProcessResponse(string retorno)
		{
			var retornoRfb = new List<string>();

			try
			{
				retorno = HttpUtility.HtmlDecode(retorno);
				retorno = retorno.StripHtml().RemoveDoubleSpaces();
				retorno = retorno.Replace("\t", string.Empty);
				retornoRfb.AddText(retorno);
				retornoRfb.RemoveEmptyLines();

				CPF = LerCampo(retornoRfb, "Nº do CPF:");
				Nome = LerCampo(retornoRfb, "Nome:");
				DataNascimento = LerCampo(retornoRfb, "Data Nascimento:").ToData();
				Situacao = LerCampo(retornoRfb, "Situação Cadastral:");
				DataInscricao = LerCampo(retornoRfb, "Data de Inscrição no CPF:").ToData();
				DigitoVerificador = LerCampo(retornoRfb, "Dígito Verificador:");
				Emissao = LerCampo(retornoRfb, "Comprovante emitido às:");
				CodCtrlControle = LerCampo(retornoRfb, "Código de controle do comprovante:");
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, "Erro ao processar retorno.");
			}

			if (!Nome.IsEmpty()) return;

			var erro = LerCampo(retornoRfb, "Data de nascimento informada");
			Guard.Against<ACBrException>(!erro.IsEmpty(), "Data de nascimento divergente da base da Receita Federal.");

			throw new ACBrException("Não foi possível obter os dados.");
		}

		private static string LerCampo(IList<string> retorno, string campo)
		{
			var ret = string.Empty;
			for (var i = 0; i < retorno.Count; i++)
			{
				var linha = retorno[i].Trim();
				if (!linha.Contains(campo)) continue;

				ret = linha.Replace(campo, string.Empty).Trim();
				retorno.RemoveAt(i);
				break;
			}

			return ret;
		}

		#endregion Methods
	}
}