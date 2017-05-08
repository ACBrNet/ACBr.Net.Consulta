using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBr.Net.Consulta.Validacoes.IEValid
{
    /// <summary>
    /// Validação da IE do Distrito Federal
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_DF.html
    /// </remarks>
    public class IEDistritoFederalValidator : IIEValidator
    {
        private string inscEstadual;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inscEstadual"></param>
        public IEDistritoFederalValidator(string inscEstadual)
        {
            this.inscEstadual = inscEstadual;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            return HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 13;
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 2);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();
            return String.Concat(firstDigit, secondDigit) == this.inscEstadual.Substring(this.inscEstadual.Length - 2, 2);
        }
    }
}
