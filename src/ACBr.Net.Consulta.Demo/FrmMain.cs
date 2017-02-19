using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Consulta.Demo
{
	public partial class FrmMain : Form
	{
		#region Constructors

		public FrmMain()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		#region EventHandlers

		private void FrmMain_Shown(object sender, EventArgs e)
		{
			RefreshCaptchaCNPJ();
			RefreshCaptchaCPF();
			cnpjMaskedTextBox.Focus();
		}

		private void captchaCnpjLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshCaptchaCNPJ();
		}

		private void procurarCnpjButton_Click(object sender, EventArgs e)
		{
			ProcurarCNPJ();
		}

		private void captchaCpfLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshCaptchaCPF();
		}

		private void procurarCpfButton_Click(object sender, EventArgs e)
		{
			ProcurarCPF();
		}

		private void procurarIbgeCodigoButton_Click(object sender, EventArgs e)
		{
			var primaryTask = Task<int>.Factory.StartNew(() => acbrIbge.BuscarPorCodigo(codigoIbgeTextBox.Text.ToInt32()));
			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void procurarIbgeNomeButton_Click(object sender, EventArgs e)
		{
			var primaryTask = Task<int>.Factory.StartNew(() => acbrIbge.BuscarPorNome(nomeIbgeTextBox.Text));
			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void OnOnBuscaEfetuada(object sender, EventArgs eventArgs)
		{
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = acbrIbge.Resultados;
		}

		#endregion EventHandlers

		private void RefreshCaptchaCNPJ()
		{
			var primaryTask = Task<Image>.Factory.StartNew(() => acbrCnpj.GetCaptcha());
			primaryTask.ContinueWith(task =>
			{
				if (task.Result.IsNull()) return;

				captchaCnpjPictureBox.Image = task.Result;
				captchaCnpjTextBox.Text = string.Empty;
			}, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void RefreshCaptchaCPF()
		{
			var primaryTask = Task<Image>.Factory.StartNew(() => acbrCpf.GetCaptcha());
			primaryTask.ContinueWith(task =>
			{
				if (task.Result.IsNull()) return;

				captchCpfPictureBox.Image = task.Result;
				captchaCpfTextBox.Text = string.Empty;
			}, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void ProcurarCNPJ()
		{
			var primaryTask = Task<ACBrEmpresa>.Factory.StartNew(() => acbrCnpj.Consulta(cnpjMaskedTextBox.Text, captchaCnpjTextBox.Text));
			primaryTask.ContinueWith(task =>
			{
				var retorno = task.Result;
				tipoEmpresaTextBox.Text = retorno.TipoEmpresa;
				razaoSocialTextBox.Text = retorno.RazaoSocial;
				dataAberturaTextBox.Text = retorno.DataAbertura.ToShortDateString();
				nomeFantasiaTextBox.Text = retorno.NomeFantasia;
				cnaePrimarioTextBox.Text = retorno.CNAE1;
				logradouroTextBox.Text = retorno.Logradouro;
				numeroTextBox.Text = retorno.Numero;
				complementoTextBox.Text = retorno.Complemento;
				bairroTextBox.Text = retorno.Bairro;
				municipioTextBox.Text = retorno.Municipio;
				ufTextBox.Text = retorno.UF;
				cepTextBox.Text = retorno.CEP;
				situacaoTextBox.Text = retorno.Situacao;
				naturezaJuridicaTextBox.Text = retorno.NaturezaJuridica;
				cnaeSecundariosTextBox.Text = retorno.CNAE2.AsString();
			}, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => RefreshCaptchaCNPJ(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void ProcurarCPF()
		{
			var primaryTask = Task<ACBrPessoa>.Factory.StartNew(() => acbrCpf.Consulta(cpfMaskedTextBox.Text, dataNascimentoMaskedTextBox.Text.ToData(), captchaCpfTextBox.Text));
			primaryTask.ContinueWith(task =>
			{
				var retorno = task.Result;
				nomeTextBox.Text = retorno.Nome;
				situacaoCpfTextBox.Text = retorno.Situacao;
				digitoTextBox.Text = retorno.DigitoVerificador;
				comprovanteTextBox.Text = retorno.Emissao;
				dataInscricaoTextBox.Text = retorno.DataInscricao.ToShortDateString();
				codControleTextBox.Text = retorno.CodCtrlControle;
			}, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString()),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => RefreshCaptchaCPF(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion Methods
	}
}