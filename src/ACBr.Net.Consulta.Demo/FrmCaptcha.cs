using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.Demo
{
	public partial class FrmCaptcha : Form
	{
		#region Fields

		private Func<Image> getCaptcha;

		#endregion Fields

		#region Constructors

		public FrmCaptcha()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		#region EventHandlers

		private void FrmCaptcha_Shown(object sender, EventArgs e)
		{
			RefreshCaptcha();
		}

		private void FrmCaptcha_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Escape) return;

			captchaTextBox.Text = string.Empty;
			Close();
		}

		private void captchaCnpjLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshCaptcha();
		}

		private void enviarCaptchaButton_Click(object sender, EventArgs e)
		{
			if (captchaTextBox.Text.IsEmpty())
			{
				MessageBox.Show(this, @"Digite o captcha !");
				return;
			}

			Close();
		}

		#endregion EventHandlers

		private void RefreshCaptcha()
		{
			var primaryTask = Task<Image>.Factory.StartNew(() => getCaptcha());
			primaryTask.ContinueWith(task =>
			{
				if (task.Result.IsNull()) return;

				captchaPictureBox.Image = task.Result;
				captchaTextBox.Text = string.Empty;
			}, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public static string GetCaptcha(Form parent, Func<Image> getCaptchaImage)
		{
			using (var form = new FrmCaptcha())
			{
				form.getCaptcha = getCaptchaImage;
				form.ShowDialog(parent);

				return form.captchaTextBox.Text;
			}
		}

		#endregion Methods
	}
}