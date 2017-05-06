using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACBr.Net.Consulta.CEP;
using ACBr.Net.Consulta.Sintegra;
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
            ufCepComboBox.EnumDataSource<ConsultaUF>(ConsultaUF.MS);
            ufSintegraComboBox.EnumDataSource<ConsultaUF>(ConsultaUF.MS);
        }

        private void procurarCnpjButton_Click(object sender, EventArgs e)
        {
            ProcurarCNPJ();
        }

        private void procurarCpfButton_Click(object sender, EventArgs e)
        {
            ProcurarCPF();
        }

        private void procurarSintegraCnpjButton_Click(object sender, EventArgs e)
        {
            LimparCamposSintegra();
            ProcurarSintegra();
            
        }

        private void LimparCamposSintegra()
        {
            razaoSocialSintegraTextBox.Text = String.Empty;
            dataAberturaSintegraTextBox.Text = String.Empty;
            cnpjSintegraTextBox.Text = String.Empty;
            ieSintegraTextBox.Text = String.Empty;
            logradouroSintegraTextBox.Text = String.Empty;
            numeroSintegraTextBox.Text = String.Empty;
            complementoSintegraTextBox.Text = String.Empty;
            bairroSintegraTextBox.Text = String.Empty;
            municipioSintegraTextBox.Text = String.Empty;
            ufSintegraTextBox.Text = String.Empty;
            cepSintegraTextBox.Text = String.Empty;
            situacaoSintegraTextBox.Text = String.Empty;
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
            var uf = (ConsultaUF)ufCepComboBox.SelectedItem;
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

        private void acbrConsultaSintegra_OnGetCaptcha(object sender, CaptchaEventArgs e)
        {
            var uf = (ConsultaUF)ufSintegraComboBox.SelectedItem;
            if (uf != ConsultaUF.GO)
            {
                e.Captcha = FrmCaptcha.GetCaptcha(this, () => acbrConsultaSintegra.GetCaptcha(uf));
            }
            
        }

        private void acbrIbge_OnBuscaEfetuada(object sender, EventArgs eventArgs)
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
                ufTextBox.Text = retorno.UF.ToString();
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

        private void ProcurarSintegra()
        {
            //
            var uf = (ConsultaUF)ufSintegraComboBox.SelectedItem;
            var cnpj = String.Empty;
            if (cnpjSintegraMaskedTextBox.Text != "  .   .   /    -")
            {
                cnpj = cnpjSintegraMaskedTextBox.Text;
            } 
            var ie = inscricaoSintegraTextBox.Text;

            var primaryTask = Task<ACBrEmpresa>.Factory.StartNew(() => acbrConsultaSintegra.Consulta(uf, cnpj, ie));
            primaryTask.ContinueWith(task =>
            {
                var retorno = task.Result;
                razaoSocialSintegraTextBox.Text = retorno.RazaoSocial;
                dataAberturaSintegraTextBox.Text = retorno.DataAbertura.ToShortDateString();
                cnpjSintegraTextBox.Text = retorno.CNPJ;
                ieSintegraTextBox.Text = retorno.InscricaoEstadual;
                logradouroSintegraTextBox.Text = retorno.Logradouro;
                numeroSintegraTextBox.Text = retorno.Numero;
                complementoSintegraTextBox.Text = retorno.Complemento;
                bairroSintegraTextBox.Text = retorno.Bairro;
                municipioSintegraTextBox.Text = retorno.Municipio;
                ufSintegraTextBox.Text = retorno.UF.ToString();
                cepSintegraTextBox.Text = retorno.CEP;
                situacaoSintegraTextBox.Text = retorno.Situacao;
            }, CancellationToken.None, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());

            primaryTask.ContinueWith(task => MessageBox.Show(this, task.Exception.InnerExceptions.Select(x => x.Message).AsString(), this.Text),
                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion Methods
    }
}