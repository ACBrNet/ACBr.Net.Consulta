using System;
using System.Collections.Generic;

namespace ACBr.Net.Consulta.Validacoes
{
    /// <summary>
    /// Classe DigitoVerificador
    /// </summary>
    public class DigitoVerificador
    {
        private string numero;
        private int modulo = 11;
        private List<int> multiplicadores = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 };
        private bool somarAlgarismos = false;
        private IDictionary<int, string> substituicoes = new Dictionary<int, string>();
        private bool complementarDoModulo = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public DigitoVerificador(string numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Determina o primeiro e o último multiplicador (ou peso) para o cálculo do dígito verificador
        /// </summary>
        public DigitoVerificador ComMultiplicadoresDeAte(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            this.multiplicadores.Clear();
            for (int i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                multiplicadores.Add(i);

            return this;
        }

        /// <summary>
        /// Determina os multiplicadores (ou pesos) para o cálculo do dígito verificador
        /// </summary>
        public DigitoVerificador ComMultiplicadores(params int[] multiplicadores)
        {
            this.multiplicadores.Clear();
            foreach (int i in multiplicadores)
            {
                this.multiplicadores.Add(i);
            }
            return this;
        }

        /// <summary>
        /// Existem algumas regras onde é necessário substituir um dígito calculado por um outro valor
        /// Ex: No caso do CNPJ, quando o divisor for menor do que 2, o dígito retornado deve ser "0"
        /// </summary>
        public DigitoVerificador Substituindo(string substituto, params int[] digitos)
        {
            foreach (int i in digitos)
            {
                substituicoes[i] = substituto;
            }
            return this;
        }

        /// <summary>
        /// Existem algumas regras onde é necessário substituir um dígito calculado por um outro valor
        /// Ex: No caso do CNPJ, quando o divisor for menor do que 2, o dígito retornado deve ser "0"
        /// </summary>
        public DigitoVerificador Modulo(int modulo)
        {
            this.modulo = modulo;
            return this;
        }

        /// <summary>
        /// Existem algumas regras onde é necessário somar todos os algarismos e não apenas o produto
        /// Ex: 4 x 5 = 20, irá somar 9 (4 + 5) invés de 20 ao total.
        /// </summary>
        public DigitoVerificador SomandoAlgarismos()
        {
            this.somarAlgarismos = true;
            return this;
        }

        /// <summary>
        /// Multiplicação da esquerda para a direita.
        /// </summary>
        public DigitoVerificador InvertendoMultiplicadores()
        {
            this.multiplicadores.Reverse();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DigitoVerificador SemComplementarDoModulo()
        {
            this.complementarDoModulo = false;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digito"></param>
        public void AddDigito(string digito)
        {
            this.numero = String.Concat(this.numero, digito);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CalculaDigito()
        {
            if (!(this.numero.Length > 0))
            {
                return "";
            }
            return GetDigitSum();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetDigitSum()
        {
            int soma = 0;
            for (int i = this.numero.Length - 1, m = 0; i >= 0; i--)
            {
                int produto = (int)char.GetNumericValue(this.numero[i]) * this.multiplicadores[m];
                soma += somarAlgarismos ? SomaAlgarismos(produto) : produto;

                if (++m >= this.multiplicadores.Count) m = 0;
            }

            int mod = (soma % modulo);
            int resultado = complementarDoModulo ? modulo - mod : mod;

            if (substituicoes.ContainsKey(resultado))
            {
                return this.substituicoes[resultado];
            }

            return resultado.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        private int SomaAlgarismos(int produto)
        {
            return (produto / 10) + (produto % 10);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="multiplicadorAtual"></param>
        /// <returns></returns>
        private int ProximoMultiplicador(int multiplicadorAtual)
        {
            return multiplicadorAtual;
        }
    }
}