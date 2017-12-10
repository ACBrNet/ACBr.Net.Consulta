// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-20-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-20-2017
// ***********************************************************************
// <copyright file="ACBrCEP.cs" company="ACBr.Net">
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
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.CEP
{
	/// <summary>
	/// Class ACBrCEP. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBr.Net.Core.ACBrComponent" />
	[ToolboxBitmap(typeof(ACBrCEP), "ACBr.Net.Consulta.ACBrCEP.bmp")]
	// ReSharper disable once InconsistentNaming
	public sealed class ACBrCEP : ACBrComponent
	{
		#region Events

		/// <summary>
		/// Evento disparado depois da buscar ser efetuada com sucesso.
		/// </summary>
		public event EventHandler<EventArgs> OnBuscaEfetuada;

		#endregion Events

		#region Propriedades

		/// <summary>
		/// Retorna ou define o webservice utilizado nas pesquisas.
		/// </summary>
		/// <value>The web service.</value>
		public CEPWebService WebService { get; set; }

		/// <summary>
		/// Retorna a lista de endereços que foram retornados pela pesquisa.
		/// </summary>
		/// <value>Os endereços.</value>
		public List<ACBrEndereco> Resultados { get; private set; }

		/// <summary>
		/// Retorna ou define a chave de acesso utilizada por alguns webservices.
		/// </summary>
		/// <value>A chave de acesso.</value>
		public string ChaveAcesso { get; set; }

		/// <summary>
		/// Retorna ou define o usuário utilizado por alguns webservices.
		/// </summary>
		/// <value>The usuario.</value>
		public string Usuario { get; set; }

		/// <summary>
		/// Retorna ou define a senha utilizada por alguns webservices.
		/// </summary>
		/// <value>The senha.</value>
		public string Senha { get; set; }

		/// <summary>
		/// Retorna ou define se deve pesquisar o IBGE caso o webservice não retorna este dado.
		/// </summary>
		/// <value><c>true</c> para pesquisar; caso contrário, <c>false</c>.</value>
		public bool PesquisarIBGE { get; set; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Buscar o endereço para o CEP passado.
		/// </summary>
		/// <param name="cep">The cep.</param>
		/// <returns>System.Int32.</returns>
		public int BuscarPorCEP(string cep)
		{
			Guard.Against<ArgumentException>(cep.IsEmpty(), "CEP não pode ser vazio.");
			Guard.Against<ArgumentException>(!cep.IsCep(), "CEP inválido.");

			Resultados.Clear();

			var provider = GetProvider();
			var results = provider.BuscarPorCEP(cep);
			Resultados.AddRange(results);

			OnBuscaEfetuada.Raise(this, EventArgs.Empty);
			return Resultados.Count;
		}

		/// <summary>
		/// Busca os dados do endereço pelo logradouro.
		/// </summary>
		/// <param name="municipio">The municipio.</param>
		/// <param name="tipoLogradouro">The tipo logradouro.</param>
		/// <param name="logradouro">The logradouro.</param>
		/// <param name="uf">The uf.</param>
		/// <param name="bairro">The bairro.</param>
		/// <returns>System.Int32.</returns>
		public int BuscarPorLogradouro(ConsultaUF uf, string municipio, string logradouro, string tipoLogradouro = "", string bairro = "")
		{
			Guard.Against<ArgumentException>(municipio.IsEmpty(), "Municipio não pode ser vazio.");
			Guard.Against<ArgumentException>(logradouro.IsEmpty(), "Logradouro não pode ser vazio.");

			Resultados.Clear();

			var provider = GetProvider();
			var results = provider.BuscarPorLogradouro(uf, municipio, logradouro, tipoLogradouro, bairro);
			Resultados.AddRange(results);

			OnBuscaEfetuada.Raise(this, EventArgs.Empty);
			return Resultados.Count;
		}

		private CepWsClass GetProvider()
		{
			switch (WebService)
			{
				case CEPWebService.None:
					throw new ACBrException("Webservice não selecionado.");

				case CEPWebService.Correios:
					return new CorreiosWebservice();

				case CEPWebService.ViaCep:
					return new ViaCepWebservice();

				default:
					throw new ACBrException("Webservice não implementado.");
			}
		}

		#region Protected Methods

		/// <summary>
		/// Called when [initialize].
		/// </summary>
		protected override void OnInitialize()
		{
			Resultados = new List<ACBrEndereco>();
			WebService = CEPWebService.None;
		}

		/// <summary>
		/// Called when [disposing].
		/// </summary>
		protected override void OnDisposing()
		{
		}

		#endregion Protected Methods

		#endregion Methods
	}
}