using ACBr.Net.Consulta.Validacoes.IEValid;

namespace ACBr.Net.Consulta.Validacoes
{
    /// <summary>
    /// 
    /// </summary>
    public class IEValidator
    {
        private static string isento = "ISENTO";
        private string ie;
        private ConsultaUF uf;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ie"></param>
        /// <param name="uf"></param>
        public IEValidator(string ie, ConsultaUF uf)
        {
            this.ie = ie;
            this.uf = uf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (ie == isento) return true;
            return IsValidByUF();
        }

        private bool IsValidByUF()
        {
            IIEValidator ieValidator = null;
            switch (this.uf)
            {
                case ConsultaUF.DF:
                    ieValidator = new IEDistritoFederalValidator(this.ie);
                    break;
                case ConsultaUF.GO:
                    ieValidator = new IEGoiasValidator(this.ie);
                    break;
            }
            if (ieValidator == null) return false;

            return ieValidator.IsValid();
        }
    }
}