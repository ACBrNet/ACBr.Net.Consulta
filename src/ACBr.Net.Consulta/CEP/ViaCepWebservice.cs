// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-26-2017
//
// Last Modified By : RFTD
// Last Modified On : 02-26-2017
// ***********************************************************************
// <copyright file="ViaCepWebservice.cs" company="ACBr.Net">
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
using System.Linq;
using System.Net;
using System.Xml.Linq;
using ACBr.Net.Core;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.CEP
{
	internal sealed class ViaCepWebservice : CepWsClass
	{
		#region Fields

		private const string VIACEP_URL = "https://viacep.com.br/ws";

		#endregion Fields

		#region Methods

		#region Interface Methods

		public override ACBrEndereco[] BuscarPorCEP(string cep)
		{
			var url = $"{VIACEP_URL}/{cep.OnlyNumbers()}/xml";
			var ret = ConsultaCEP(url);
			return ret.ToArray();
		}

		public override ACBrEndereco[] BuscarPorLogradouro(ConsultaUF uf, string municipio, string logradouro, string tipoLogradouro = "", string bairro = "")
		{
			var url = $"{VIACEP_URL}/{uf}/{municipio.ToLower().ToTitleCase()}/{logradouro.ToLower().ToTitleCase()}/xml";
			var ret = ConsultaCEP(url);

			if (!tipoLogradouro.IsEmpty())
			{
				ret.RemoveAll(x => !string.Equals(x.TipoLogradouro.RemoveAccent(), tipoLogradouro.RemoveAccent(), StringComparison.CurrentCultureIgnoreCase));
			}

			if (!bairro.IsEmpty())
			{
				ret.RemoveAll(x => !string.Equals(x.Bairro.RemoveAccent(), bairro.RemoveAccent(), StringComparison.CurrentCultureIgnoreCase));
			}

			return ret.ToArray();
		}

		#endregion Interface Methods

		#region Private Methods

		private static List<ACBrEndereco> ConsultaCEP(string url)
		{
			try
			{
				var webRequest = (HttpWebRequest)WebRequest.Create(url);
				webRequest.ProtocolVersion = HttpVersion.Version10;
				webRequest.UserAgent = "Mozilla/4.0 (compatible; Synapse)";

				webRequest.KeepAlive = true;
				webRequest.Headers.Add(HttpRequestHeader.KeepAlive, "300");

				var response = webRequest.GetResponse();
				var xmlStream = response.GetResponseStream();
				var doc = XDocument.Load(xmlStream);

				var ret = new List<ACBrEndereco>();

				var rootElement = doc.Element("xmlcep");
				if (rootElement == null) return ret;

				if (rootElement.Element("enderecos") != null)
				{
					var element = rootElement.Element("enderecos");
					if (element == null) return ret;

					var elements = element.Elements("endereco");
					ret.AddRange(elements.Select(ProcessElement));
				}
				else
				{
					var endereco = ProcessElement(rootElement);
					ret.Add(endereco);
				}

				return ret;
			}
			catch (Exception e)
			{
				throw new ACBrException(e, "Erro ao consutar CEP.");
			}
		}

		private static ACBrEndereco ProcessElement(XElement element)
		{
			var endereco = new ACBrEndereco
			{
				CEP = element.ElementAnyNs("cep").GetValue<string>(),
				Logradouro = element.ElementAnyNs("logradouro").GetValue<string>(),
				Complemento = element.ElementAnyNs("complemento").GetValue<string>(),
				Bairro = element.ElementAnyNs("bairro").GetValue<string>(),
				Municipio = element.ElementAnyNs("localidade").GetValue<string>(),
				UF = element.ElementAnyNs("uf").GetValue<ConsultaUF>(),
				IBGEMunicipio = element.ElementAnyNs("ibge").GetValue<string>(),
			};

			endereco.TipoLogradouro = endereco.Logradouro.Split(' ')[0];
			endereco.Logradouro = endereco.Logradouro.SafeReplace(endereco.TipoLogradouro, string.Empty);

			return endereco;
		}

		#endregion Private Methods

		#endregion Methods
	}
}