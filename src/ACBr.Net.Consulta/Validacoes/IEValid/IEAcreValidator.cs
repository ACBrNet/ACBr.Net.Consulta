using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBr.Net.Consulta.Validacoes.IEValid
{
    /// <summary>
    /// 
    /// </summary>
    class IEAcreValidator: IIEValidator
    {
        private string inscEstadual;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ie"></param>
        public IEAcreValidator(string ie)
        {
            this.inscEstadual = ie;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (!IsSizeValid()) return false;
            if (!IsFirstDigitsValid()) return false;
            return HasValidCheckDigits();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 13;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsFirstDigitsValid()
        {
            return this.inscEstadual.Substring(0, 2) == "01";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 2);

            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                    .ComMultiplicadoresDeAte(2, 9)
                                                    .Substituindo("0", 10, 11);
            string firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            string secondDigit = digitoVerificador.CalculaDigito();

            return String.Concat(firstDigit, secondDigit) == this.inscEstadual.Substring(this.inscEstadual.Length - 2, 2);
        }
    }
}
