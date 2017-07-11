// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : Regis Araujo
// Created          : 05-07-2017
//
// Last Modified By : RFTD
// Last Modified On : 05-08-2017
// *********************************************************************
// <copyright file="ConsultaExtensions.cs" company="ACBr.Net">
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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;

namespace ACBr.Net.Consulta
{
    /// <summary>
    /// Classe com metodos de extensão
    /// </summary>
    public static class ConsultaExtensions
    {
        #region Fields

        private static readonly IDictionary<int, string> DescricaoUF = new Dictionary<int, string>()
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
            return DescricaoUF[(int)uf];
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

        /// <summary>
        /// Envia um post com os dados informados.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        internal static string SendPost(this HttpWebRequest request, Dictionary<string, string> postData)
        {
            return SendPost(request, postData, ACBrEncoding.ISO88591);
        }

        /// <summary>
        /// Envia um post com os dados informados e utilizando o encoding.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postData"></param>
        /// <param name="enconde"></param>
        /// <returns></returns>
        internal static string SendPost(this HttpWebRequest request, Dictionary<string, string> postData, Encoding enconde)
        {
            request.Method = "POST";

            var post = new StringBuilder();
            var lastKey = postData.Last().Key;
            foreach (var postValue in postData)
            {
                post.Append($"{postValue.Key}={postValue.Value}");
                if (postValue.Key != lastKey) post.Append("&");
            }

            var byteArray = enconde.GetBytes(post.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            Guard.Against<ACBrException>(responseStream == null, "Erro ao acessar o site.");

            string retorno;
            using (var stHtml = new StreamReader(responseStream, enconde))
                retorno = stHtml.ReadToEnd();

            return retorno;
        }

        #endregion Methods
    }
}