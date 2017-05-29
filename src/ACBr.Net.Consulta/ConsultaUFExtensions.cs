// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : Regis Araujo
// Created          : 05-07-2017
//
// Last Modified By : RFTD
// Last Modified On : 05-08-2017
// *********************************************************************
// <copyright file="ConsultaUF.cs" company="ACBr.Net">
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

using System.Collections.Generic;

namespace ACBr.Net.Consulta
{
	/// <summary>
	/// Classe com metodos de extensão para o Enum ConsultaUF
	/// </summary>
	public static class ConsultaUFExtensions
	{
		#region Fields

		private static IDictionary<int, string> descricaoUF = new Dictionary<int, string>()
		{
			{11, "Rondônia"},
			{12, "Acre"},
			{13, "Amazonas"},
			{14, "Roraima"},
			{15, "Pará"},
			{16, "Amapá"},
			{17, "Tocantins"},
			{21, "Maranhão"},
			{22, "Piauí"},
			{23, "Ceará"},
			{24, "Rio Grande do Norte"},
			{25, "Paraíba"},
			{26, "Pernambuco"},
			{27, "Alagoas"},
			{28, "Sergipe"},
			{29, "Bahia"},
			{31, "Minas Gerais"},
			{32, "Espírito Santo"},
			{33, "Rio de Janeiro"},
			{35, "São Paulo"},
			{41, "Paraná"},
			{42, "Santa Catarina"},
			{43, "Rio Grande do Sul"},
			{50, "Mato Grosso do Sul"},
			{51, "Mato Grosso"},
			{52, "Goiás"},
			{53, "Distrito Federal"}
		};

		#endregion Fields

		#region Methods

		/// <summary>
		///
		/// </summary>
		/// <param name="uf"></param>
		/// <returns></returns>
		public static int Codigo(this ConsultaUF uf)
		{
			return (int)uf;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="uf"></param>
		/// <returns></returns>
		public static string Nome(this ConsultaUF uf)
		{
			return descricaoUF[(int)uf];
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="uf"></param>
		/// <returns></returns>
		public static string Sigla(this ConsultaUF uf)
		{
			return uf.ToString();
		}

		#endregion Methods
	}
}