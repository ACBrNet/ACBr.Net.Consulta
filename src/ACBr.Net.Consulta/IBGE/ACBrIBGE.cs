// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-18-2017
//
// Last Modified By : RFTD
// Last Modified On : 05-08-2017
// ***********************************************************************
// <copyright file="ACBrIBGE.cs" company="ACBr.Net">
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
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.IBGE
{
	/// <summary>
	/// Class ACBrIBGE. This class cannot be inherited.
	/// </summary>
	/// <seealso cref="ACBrComponentConsulta" />
	[ToolboxBitmap(typeof(ACBrIBGE), "ACBr.Net.Consulta.ACBrIBGE.bmp")]
	public sealed class ACBrIBGE : ACBrComponentConsulta
	{
		#region Fields

		private const string CIBGE_URL = "http://www.ibge.gov.br/home/geociencias/areaterritorial/area.php";

		#endregion Fields

		#region Events

		public event EventHandler<EventArgs> OnBuscaEfetuada;

		#endregion Events

		#region Properties

		/// <summary>
		/// Resultado da busca
		/// </summary>
		public List<ACBrMunicipio> Resultados { get; private set; }

		#endregion Properties

		#region Methods

		/// <summary>
		/// Busca os dados do IBGE pelo codigo do Municipio
		/// </summary>
		/// <param name="codigo"></param>
		/// <returns></returns>
		public int BuscarPorCodigo(int codigo)
		{
			Guard.Against<ArgumentException>(codigo < 1, "Código do Município deve ser informado");

			var request = GetClient($"{CIBGE_URL}?codigo={codigo}");
			var responseStream = request.GetResponse().GetResponseStream();
			Guard.Against<ACBrException>(responseStream == null, "Erro ao acessar o site.");

			string retorno;
			using (var stHtml = new StreamReader(responseStream, ACBrEncoding.ISO88591))
				retorno = stHtml.ReadToEnd();

			ProcessarResposta(retorno);

			var result = Resultados.Count;
			OnBuscaEfetuada.Raise(this, EventArgs.Empty);
			return result;
		}

		/// <summary>
		/// Busca os dados do IBGE pelo nome do Municipio
		/// </summary>
		/// <param name="municipio">The municipio.</param>
		/// <param name="uf">The uf.</param>
		/// <param name="exata">if set to <c>true</c> [exata].</param>
		/// <param name="caseSentive">if set to <c>true</c> [case sentive].</param>
		/// <returns>System.Int32.</returns>
		public int BuscarPorNome(string municipio, ConsultaUF? uf = null, bool exata = false, bool caseSentive = false)
		{
			Guard.Against<ArgumentException>(municipio.IsEmpty(), "Município deve ser informado");

			var request = GetClient($"{CIBGE_URL}?nome={HttpUtility.UrlEncode(municipio.Trim(), ACBrEncoding.ISO88591)}");

			var responseStream = request.GetResponse().GetResponseStream();
			Guard.Against<ACBrException>(responseStream.IsNull(), "Erro ao acessar o site.");

			string retorno;
			using (var stHtml = new StreamReader(responseStream, ACBrEncoding.ISO88591))
				retorno = stHtml.ReadToEnd();

			ProcessarResposta(retorno);

			if (uf.HasValue)
			{
				Resultados.RemoveAll(x => x.UF != uf);
			}

			if (exata)
			{
				if (caseSentive)
					Resultados.RemoveAll(x => x.Nome.RemoveAccent() != municipio.RemoveAccent());
				else
					Resultados.RemoveAll(x => x.Nome.ToUpper().RemoveAccent() != municipio.ToUpper().RemoveAccent());
			}

			var result = Resultados.Count;
			OnBuscaEfetuada.Raise(this, EventArgs.Empty);
			return result;
		}

		#region Private Methods

		private void ProcessarResposta(string resposta)
		{
			try
			{
				Resultados.Clear();

				var buffer = resposta.ToLower();
				var pos = buffer.IndexOf("<div id=\"miolo_interno\">", StringComparison.Ordinal);
				if (pos <= 0) return;

				buffer = buffer.Substring(pos, buffer.Length - pos);
				buffer = buffer.GetStrBetween("<table ", "</table>");

				var rows = Regex.Matches(buffer, @"(?<1><TR[^>]*>\s*<td.*?</tr>)", RegexOptions.Singleline | RegexOptions.IgnoreCase)
								.Cast<Match>()
								.Select(t => t.Value)
								.ToArray();

				if (rows.Length < 2) return;

				for (var i = 1; i < rows.Length; i++)
				{
					var columns = Regex.Matches(rows[i], @"<td[^>](.+?)<\/td>", RegexOptions.Singleline | RegexOptions.IgnoreCase)
									   .Cast<Match>()
									   .Select(t => t.Value.StripHtml().Replace("&nbsp;", string.Empty).Trim())
									   .ToArray();

					var municipio = new ACBrMunicipio
					{
						CodigoUF = columns[0].ToInt32(),
						UF = (ConsultaUF)Enum.Parse(typeof(ConsultaUF), columns[1].ToUpper()),
						Codigo = columns[2].ToInt32(),
						Nome = columns[3].ToTitleCase(),
						Area = columns[4].ToDecimal()
					};

					Resultados.Add(municipio);
				}
			}
			catch (Exception exception)
			{
				throw new ACBrException(exception, "Erro ao processar retorno.");
			}
		}

		#endregion Private Methods

		#region Protected Method

		/// <inheritdoc />
		protected override void OnInitialize()
		{
			base.OnInitialize();
			Resultados = new List<ACBrMunicipio>();
		}

		#endregion Protected Method

		#endregion Methods
	}
}