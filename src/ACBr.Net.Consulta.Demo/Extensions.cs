using System;
using System.Windows.Forms;
using ACBr.Net.Core.Exceptions;

namespace ACBr.Net.Consulta.Demo
{
	public static class Extensions
	{
		public static void EnumDataSource<T>(this ComboBox cmb, T? valorPadrao = null) where T : struct
		{
			Guard.Against<ArgumentException>(!typeof(T).IsEnum, "O tipo precisar ser um Enum.");

			cmb.DataSource = Enum.GetValues(typeof(T));
			if (valorPadrao.HasValue) cmb.SelectedItem = valorPadrao.Value;
		}
	}
}