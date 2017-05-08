using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBr.Net.Consulta.Validacoes
{
    /// <summary>
    /// Classe CNPJ
    /// </summary>
    public class CNPJ
    {
        /// <summary>
        /// Numero do CPF sem Mascara
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Funcao para validacao do numero Cnpj.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return new CNPJValidator(this.Numero).IsValid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        public CNPJ(string cnpj)
        {
            this.Numero = SemFormatacao(cnpj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace(",", string.Empty);
        }
    }
}
