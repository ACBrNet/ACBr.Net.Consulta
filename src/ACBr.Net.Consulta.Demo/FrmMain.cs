using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACBr.Net.Consulta.CEP;
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
			cnpjMaskedTextBox.Focus();
			webserviceCepComboBox.EnumDataSource<CEPWebService>(CEPWebService.None);
		}

		private void procurarCnpjButton_Click(object sender, EventArgs e)
		{
			ProcurarCNPJ();
		}

		private void procurarCpfButton_Click(object sender, EventArgs e)
		{
			ProcurarCPF();
		}

		private void procurarIbgeCodigoButton_Click(object sender, EventArgs e)
		{
			var primaryTask = Task<int>.Factory.StartNew(() => acbrIbge.BuscarPorCodigo(codigoIbgeTextBox.Text.ToInt32()));
			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void procurarIbgeNomeButton_Click(object sender, EventArgs e)
		{
			var primaryTask = Task<int>.Factory.StartNew(() => acbrIbge.BuscarPorNome(nomeIbgeTextBox.Text));
			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void buscaCepButton_Click(object sender, EventArgs e)
		{
			var primaryTask = Task<int>.Factory.StartNew(() => acbrCEP.BuscarPorCEP(cepTextBox.Text));
			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void buscaLogradouroButton_Click(object sender, EventArgs e)
		{
			var uf = ufComboBox.SelectedItem.ToString();
			var municipio = municipioCepTextBox.Text;
			var logradouro = logradouroCepTextBox.Text;

			var primaryTask = Task<int>.Factory.StartNew(() => acbrCEP.BuscarPorLogradouro(uf, municipio, logradouro));
			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void webserviceCepComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			acbrCEP.WebService = (CEPWebService)webserviceCepComboBox.SelectedItem;
		}

		private void acbrCpf_OnGetCaptcha(object sender, CaptchaEventArgs e)
		{
			e.Captcha = FrmCaptcha.GetCaptcha(this, () => acbrCpf.GetCaptcha());
		}

		private void acbrCnpj_OnGetCaptcha(object sender, CaptchaEventArgs e)
		{
			e.Captcha = FrmCaptcha.GetCaptcha(this, () => acbrCnpj.GetCaptcha());
		}

		private void acbrIbge_OnOnBuscaEfetuada(object sender, EventArgs eventArgs)
		{
			ibgeDataGridView.DataSource = null;
			ibgeDataGridView.DataSource = acbrIbge.Resultados;
		}

		private void acbrCEP_OnBuscaEfetuada(object sender, EventArgs e)
		{
			cepDataGridView.DataSource = null;
			cepDataGridView.DataSource = acbrCEP.Resultados;
		}

		#endregion EventHandlers

		private void ProcurarCNPJ()
		{
			var primaryTask = Task<ACBrEmpresa>.Factory.StartNew(() => acbrCnpj.Consulta(cnpjMaskedTextBox.Text));
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
				cepCnpjTextBox.Text = retorno.CEP;
				situacaoTextBox.Text = retorno.Situacao;
				naturezaJuridicaTextBox.Text = retorno.NaturezaJuridica;
				cnaeSecundariosTextBox.Text = retorno.CNAE2.AsString();
			}, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void ProcurarCPF()
		{
			var primaryTask = Task<ACBrPessoa>.Factory.StartNew(() => acbrCpf.Consulta(cpfMaskedTextBox.Text, dataNascimentoMaskedTextBox.Text.ToData()));
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

			primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
				CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion Methods
	}
}