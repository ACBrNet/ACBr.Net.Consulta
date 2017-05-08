using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBr.Net.Consulta.Validacoes
{
    /// <summary>
    /// Classe IE - Inscricao Estadual
    /// </summary>
    public class IE
    {
        private ConsultaUF uf;
        private string ie;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inscEstatual"></param>
        /// <param name="pUf"></param>
        public IE(string inscEstatual, ConsultaUF pUf)
        {
            this.ie = SemFormatacao(inscEstatual);
            this.uf = pUf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            IEValidator validatorIE = new IEValidator(ie, uf);
            return validatorIE.IsValid();
        }

        public string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace(",", string.Empty);
        }

    }
}
