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
		internal ACBrEmpresa()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Retorna o CNPJ.
		/// </summary>
		/// <value>O CNPJ.</value>
		public string CNPJ { get; internal set; }

		/// <summary>
		/// Retorna a inscrição estadual.
		/// </summary>
		/// <value>The inscricao estadual.</value>
		public string InscricaoEstadual { get; internal set; }

		/// <summary>
		/// Retorna o tipo empresa.
		/// </summary>
		/// <value>O tipo empresa.</value>
		public string TipoEmpresa { get; internal set; }

		/// <summary>
		/// Retorna a data abertura.
		/// </summary>
		/// <value>A data abertura.</value>
		public DateTime DataAbertura { get; internal set; }

		/// <summary>
		/// Retorna a razao social.
		/// </summary>
		/// <value>The razao social.</value>
		public string RazaoSocial { get; internal set; }

		/// <summary>
		/// Retorna o Nome Fantasia.
		/// </summary>
		/// <value>The nomefantasia.</value>
		public string NomeFantasia { get; internal set; }

		/// <summary>
		/// Retorna o cna e1.
		/// </summary>
		/// <value>The cna e1.</value>
		public string CNAE1 { get; internal set; }

		/// <summary>
		/// Gets the atividade economica.
		/// </summary>
		/// <value>The atividade economica.</value>
		public string AtividadeEconomica { get; internal set; }

		/// <summary>
		/// Retorna o logradouro.
		/// </summary>
		/// <value>The logradouro.</value>
		public string Logradouro { get; internal set; }

		/// <summary>
		/// Retorna o numero.
		/// </summary>
		/// <value>The numero.</value>
		public string Numero { get; internal set; }

		/// <summary>
		/// Retorna o complemento.
		/// </summary>
		/// <value>The complemento.</value>
		public string Complemento { get; internal set; }

		/// <summary>
		/// Retorna o cep.
		/// </summary>
		/// <value>The cep.</value>
		public string CEP { get; internal set; }

		/// <summary>
		/// Retorna o bairro.
		/// </summary>
		/// <value>The bairro.</value>
		public string Bairro { get; internal set; }

		/// <summary>
		/// Retorna o municipio.
		/// </summary>
		/// <value>The municipio.</value>
		public string Municipio { get; internal set; }

		/// <summary>
		/// Retorna o uf.
		/// </summary>
		/// <value>The uf.</value>
		public ConsultaUF UF { get; internal set; }

		/// <summary>
		/// Retorna o situacao.
		/// </summary>
		/// <value>The situacao.</value>
		public string Situacao { get; internal set; }

		/// <summary>
		/// Retorna o data situacao.
		/// </summary>
		/// <value>The data situacao.</value>
		public DateTime DataSituacao { get; internal set; }

		/// <summary>
		/// Retorna o natureza juridica.
		/// </summary>
		/// <value>The natureza juridica.</value>
		public string NaturezaJuridica { get; internal set; }

		/// <summary>
		/// Retorna o end eletronico.
		/// </summary>
		/// <value>The end eletronico.</value>
		public string EndEletronico { get; internal set; }

		/// <summary>
		/// Retorna o telefone.
		/// </summary>
		/// <value>The telefone.</value>
		public string Telefone { get; internal set; }

		/// <summary>
		/// Retorna o ENTE FEDERATIVO RESPONSÁVEL (EFR).
		/// </summary>
		/// <value>The efr.</value>
		public string EFR { get; internal set; }

		/// <summary>
		/// Retorna o motivo situacao.
		/// </summary>
		/// <value>The motivo situacao.</value>
		public string MotivoSituacao { get; internal set; }

		/// <summary>
		/// Retorna o cna e2.
		/// </summary>
		/// <value>The cna e2.</value>
		public string[] CNAE2 { get; internal set; }

		/// <summary>
		/// Retorna o situacao especial.
		/// </summary>
		/// <value>The situacao especial.</value>
		public string SituacaoEspecial { get; internal set; }

		/// <summary>
		/// Retorna o data situacao especial.
		/// </summary>
		/// <value>The data situacao especial.</value>
		public DateTime DataSituacaoEspecial { get; internal set; }

		/// <summary>
		/// Gets the data inicio atividade.
		/// </summary>
		/// <value>The data inicio atividade.</value>
		public DateTime DataInicioAtividade { get; internal set; }

		/// <summary>
		/// Gets the regime apuracao.
		/// </summary>
		/// <value>The regime apuracao.</value>
		public string RegimeApuracao { get; internal set; }

		/// <summary>
		/// Gets the data emitente n fe.
		/// </summary>
		/// <value>The data emitente n fe.</value>
		public DateTime DataEmitenteNFe { get; internal set; }

		#endregion Properties
	}
}