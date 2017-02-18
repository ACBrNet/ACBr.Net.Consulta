using System.Collections.Generic;
using System.Text.RegularExpressions;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta
{
	internal static class ConsultaHelpers
	{
		/// <summary>
		/// Remove as tag HTML do texto.
		/// </summary>
		/// <param name="htmlString">The HTML string.</param>
		/// <returns>System.String.</returns>
		public static string StripHtml(string htmlString)
		{
			const string PATTERN = @"<(.|\n)*?>";
			return Regex.Replace(htmlString, PATTERN, string.Empty);
		}

		/// <summary>
		/// Remove as linhas vazias da lista.
		/// </summary>
		/// <param name="retorno">The retorno.</param>
		public static void RemoveEmptyLines(IList<string> retorno)
		{
			var i = 0;
			while (i < retorno.Count)
			{
				if (retorno[i].IsEmpty())
				{
					retorno.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}

		/// <summary>
		/// Remove os espaços duplicados da string.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>System.String.</returns>
		public static string RemoveDoubleSpaces(string value)
		{
			return Regex.Replace(value, "[ ]{2,}", " ", RegexOptions.None);
		}
	}
}