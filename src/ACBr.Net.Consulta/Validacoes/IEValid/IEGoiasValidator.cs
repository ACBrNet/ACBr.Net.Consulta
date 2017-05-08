using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBr.Net.Consulta.Validacoes.IEValid
{
    /// <summary>
    /// Validação da IE de Goiás
    /// </summary>
    /// <remarks>
    /// ROTEIRO DE CRÍTICA DA INSCRIÇÃO ESTADUAL: 
    ///   http://www.sintegra.gov.br/Cad_Estados/cad_ES.html
    /// </remarks>
    public class IEGoiasValidator : IIEValidator
    {
        private string inscEstadual;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inscEstadual"></param>
        public IEGoiasValidator(string inscEstadual)
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
            if (!BeginsCorrectly()) return false;
            return ForNumeroMalucoDeGoias() || HasValidCheckDigits();
        }

        private bool IsSizeValid()
        {
            return this.inscEstadual.Length == 9;
        }

        private bool BeginsCorrectly()
        {
            string beginIE = this.inscEstadual.Substring(0, 2);
            string[] correctBegins = { "10", "11", "15" };
            return correctBegins.Contains(beginIE);
        }

        private bool HasValidCheckDigits()
        {
            string number = this.inscEstadual.Substring(0, this.inscEstadual.Length - 1);

            bool seEstiverNoLimite = Convert.ToInt64(number) >= Convert.ToInt64("10103105")
                                    && Convert.ToInt64(number) <= Convert.ToInt64("10119997");

            string substituto = seEstiverNoLimite ? "1" : "0";
            DigitoVerificador digitoVerificador = new DigitoVerificador(number)
                                                        .ComMultiplicadoresDeAte(2, 9)
                                                        .Substituindo(substituto, 10)
                                                        .Substituindo("0", 11);
            return digitoVerificador.CalculaDigito() == this.inscEstadual.Substring(this.inscEstadual.Length - 1, 1);
        }

        /// <summary>
        /// Quando a inscrição for 11094402 o dígito verificador pode ser zero (0) ou (1);
        /// </summary>
        private bool ForNumeroMalucoDeGoias()
        {
            string[] numerosMalucos = { "110944020", "110944021" };
            return numerosMalucos.Contains(this.inscEstadual);
        }
    }
}
