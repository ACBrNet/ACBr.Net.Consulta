// ***********************************************************************
// Assembly         : ACBr.Net.Consulta
// Author           : RFTD
// Created          : 02-20-2017
// *********************************************************************
// Last Modified By : Regis Araujo
// Last Modified On : 07-MAIO-2017
// *********************************************************************
// Last Modified By : RFTD
// Last Modified On : 02-20-2017
// *********************************************************************
// <copyright file="ConsultaSintegraMS.cs" company="ACBr.Net">
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
    /// 
    /// </summary>
    public enum ConsultaUF
    {
        /// <summary>
        /// Acre
        /// </summary>
        AC = 12,
        /// <summary>
        /// Alagoas
        /// </summary>
        AL = 27,
        /// <summary>
        /// Amazonas
        /// </summary>
        AM = 13,
        /// <summary>
        /// Amapá
        /// </summary>
        AP = 16,
        /// <summary>
        /// Bahia
        /// </summary>
        BA = 29,
        /// <summary>
        /// Ceará
        /// </summary>
        CE = 23,
        /// <summary>
        /// Distrito Federal
        /// </summary>
        DF = 53,
        /// <summary>
        /// Espírito Santo
        /// </summary>
        ES = 32,
        /// <summary>
        /// Goiás
        /// </summary>
        GO = 52,
        /// <summary>
        /// Maranhão
        /// </summary>
        MA = 21,
        /// <summary>
        /// Minas Gerais
        /// </summary>
        MG = 31,
        /// <summary>
        /// Mato Grosso do Sul
        /// </summary>
        MS = 50,
        /// <summary>
        /// Mato Grosso
        /// </summary>
        MT = 51,
        /// <summary>
        /// Pará
        /// </summary>
        PA = 15,
        /// <summary>
        /// Paraíba
        /// </summary>
        PB = 25,
        /// <summary>
        /// Pernambuco
        /// </summary>
        PE = 26,
        /// <summary>
        /// Piauí
        /// </summary>
        PI = 22,
        /// <summary>
        /// Paraná
        /// </summary>
        PR = 41,
        /// <summary>
        /// Rio de Janeiro
        /// </summary>
        RJ = 33,
        /// <summary>
        /// Rio Grande do Norte
        /// </summary>
        RN = 24,
        /// <summary>
        /// Rondônia
        /// </summary>
        RO = 11,
        /// <summary>
        /// Roraima
        /// </summary>
        RR = 14,
        /// <summary>
        /// Rio Grande do Sul
        /// </summary>
        RS = 43,
        /// <summary>
        /// Santa Catarina
        /// </summary>
        SC = 42,
        /// <summary>
        /// Sergipe
        /// </summary>
        SE = 28,
        /// <summary>
        /// São Paulo
        /// </summary>
        SP = 35,
        /// <summary>
        /// Tocantins
        /// </summary>
        TO = 17,
        /// <summary>
        /// NA
        /// </summary>
        AN = 91
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
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

        /// <summary>
        /// 
        /// </summary>
        public static ConsultaUF uf;
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
    }
}