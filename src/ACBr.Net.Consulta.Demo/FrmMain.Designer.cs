using ACBr.Net.Consulta.IBGE;
using ACBr.Net.Consulta.Receita;

namespace ACBr.Net.Consulta.Demo
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.cnpjMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cnaeSecundariosTextBox = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.naturezaJuridicaTextBox = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.situacaoTextBox = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cepCnpjTextBox = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.ufTextBox = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.municipioTextBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cnaePrimarioTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.bairroTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.complementoTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.numeroTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.logradouroTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.nomeFantasiaTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.dataAberturaTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.razaoSocialTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tipoEmpresaTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.consultaTabControl = new System.Windows.Forms.TabControl();
			this.cnpjTabPage = new System.Windows.Forms.TabPage();
			this.procurarCnpjButton = new System.Windows.Forms.Button();
			this.cpfTabPage = new System.Windows.Forms.TabPage();
			this.dataNascimentoMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.codControleTextBox = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.comprovanteTextBox = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.digitoTextBox = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.dataInscricaoTextBox = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.situacaoCpfTextBox = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.nomeTextBox = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.procurarCpfButton = new System.Windows.Forms.Button();
			this.cpfMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.sintegraTabPage = new System.Windows.Forms.TabPage();
			this.label49 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.inscricaoSintegraTextBox = new System.Windows.Forms.TextBox();
			this.ufSintegraComboBox = new System.Windows.Forms.ComboBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.situacaoSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.cepSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.ufSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.municipioSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.ieSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.bairroSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.complementoSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.numeroSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.logradouroSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.cnpjSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.dataAberturaSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.razaoSocialSintegraTextBox = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.procurarSintegraCnpjButton = new System.Windows.Forms.Button();
			this.cnpjSintegraMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.ibgeTabPage = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ibgeDataGridView = new System.Windows.Forms.DataGridView();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.procurarIbgeNomeButton = new System.Windows.Forms.Button();
			this.label27 = new System.Windows.Forms.Label();
			this.nomeIbgeTextBox = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.procurarIbgeCodigoButton = new System.Windows.Forms.Button();
			this.codigoIbgeTextBox = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.cepTabPage = new System.Windows.Forms.TabPage();
			this.cepTabControl = new System.Windows.Forms.TabControl();
			this.configuraCepTabPage = new System.Windows.Forms.TabPage();
			this.label31 = new System.Windows.Forms.Label();
			this.webserviceCepComboBox = new System.Windows.Forms.ComboBox();
			this.consultaCepTabPage = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.buscaCepButton = new System.Windows.Forms.Button();
			this.cepTextBox = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.label30 = new System.Windows.Forms.Label();
			this.logradouroCepTextBox = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.ufCepComboBox = new System.Windows.Forms.ComboBox();
			this.buscaLogradouroButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.municipioCepTextBox = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cepDataGridView = new System.Windows.Forms.DataGridView();
			this.acbrCnpj = new ACBr.Net.Consulta.Receita.ACBrConsultaCNPJ();
			this.acbrCpf = new ACBr.Net.Consulta.Receita.ACBrConsultaCPF();
			this.acbrIbge = new ACBr.Net.Consulta.IBGE.ACBrIBGE();
			this.acbrCEP = new ACBr.Net.Consulta.CEP.ACBrCEP();
			this.acbrConsultaSintegra = new ACBr.Net.Consulta.Sintegra.ACBrConsultaSintegra();
			this.groupBox1.SuspendLayout();
			this.consultaTabControl.SuspendLayout();
			this.cnpjTabPage.SuspendLayout();
			this.cpfTabPage.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.sintegraTabPage.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.ibgeTabPage.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ibgeDataGridView)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.cepTabPage.SuspendLayout();
			this.cepTabControl.SuspendLayout();
			this.configuraCepTabPage.SuspendLayout();
			this.consultaCepTabPage.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cepDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// cnpjMaskedTextBox
			// 
			this.cnpjMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cnpjMaskedTextBox.Location = new System.Drawing.Point(8, 23);
			this.cnpjMaskedTextBox.Mask = "00.000.000\\/0000-00";
			this.cnpjMaskedTextBox.Name = "cnpjMaskedTextBox";
			this.cnpjMaskedTextBox.Size = new System.Drawing.Size(273, 38);
			this.cnpjMaskedTextBox.TabIndex = 3;
			this.cnpjMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Digite o CNPJ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cnaeSecundariosTextBox);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.naturezaJuridicaTextBox);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.situacaoTextBox);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.cepCnpjTextBox);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.ufTextBox);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.municipioTextBox);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.cnaePrimarioTextBox);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.bairroTextBox);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.complementoTextBox);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.numeroTextBox);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.logradouroTextBox);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.nomeFantasiaTextBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.dataAberturaTextBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.razaoSocialTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tipoEmpresaTextBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(6, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(631, 436);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// cnaeSecundariosTextBox
			// 
			this.cnaeSecundariosTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.cnaeSecundariosTextBox.Location = new System.Drawing.Point(9, 265);
			this.cnaeSecundariosTextBox.Multiline = true;
			this.cnaeSecundariosTextBox.Name = "cnaeSecundariosTextBox";
			this.cnaeSecundariosTextBox.ReadOnly = true;
			this.cnaeSecundariosTextBox.Size = new System.Drawing.Size(616, 165);
			this.cnaeSecundariosTextBox.TabIndex = 29;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(6, 249);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(98, 13);
			this.label17.TabIndex = 28;
			this.label17.Text = "CNAE Secundários";
			// 
			// naturezaJuridicaTextBox
			// 
			this.naturezaJuridicaTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.naturezaJuridicaTextBox.Location = new System.Drawing.Point(9, 226);
			this.naturezaJuridicaTextBox.Name = "naturezaJuridicaTextBox";
			this.naturezaJuridicaTextBox.ReadOnly = true;
			this.naturezaJuridicaTextBox.Size = new System.Drawing.Size(272, 20);
			this.naturezaJuridicaTextBox.TabIndex = 27;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 210);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(91, 13);
			this.label16.TabIndex = 26;
			this.label16.Text = "Natureza Jurídica";
			// 
			// situacaoTextBox
			// 
			this.situacaoTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.situacaoTextBox.Location = new System.Drawing.Point(434, 188);
			this.situacaoTextBox.Name = "situacaoTextBox";
			this.situacaoTextBox.ReadOnly = true;
			this.situacaoTextBox.Size = new System.Drawing.Size(191, 20);
			this.situacaoTextBox.TabIndex = 25;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(431, 172);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 13);
			this.label15.TabIndex = 24;
			this.label15.Text = "Situação Cadastral";
			// 
			// cepCnpjTextBox
			// 
			this.cepCnpjTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.cepCnpjTextBox.Location = new System.Drawing.Point(324, 188);
			this.cepCnpjTextBox.Name = "cepCnpjTextBox";
			this.cepCnpjTextBox.ReadOnly = true;
			this.cepCnpjTextBox.Size = new System.Drawing.Size(104, 20);
			this.cepCnpjTextBox.TabIndex = 23;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(321, 172);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(28, 13);
			this.label14.TabIndex = 22;
			this.label14.Text = "CEP";
			// 
			// ufTextBox
			// 
			this.ufTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.ufTextBox.Location = new System.Drawing.Point(287, 188);
			this.ufTextBox.Name = "ufTextBox";
			this.ufTextBox.ReadOnly = true;
			this.ufTextBox.Size = new System.Drawing.Size(31, 20);
			this.ufTextBox.TabIndex = 21;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(284, 172);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(21, 13);
			this.label13.TabIndex = 20;
			this.label13.Text = "UF";
			// 
			// municipioTextBox
			// 
			this.municipioTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.municipioTextBox.Location = new System.Drawing.Point(9, 188);
			this.municipioTextBox.Name = "municipioTextBox";
			this.municipioTextBox.ReadOnly = true;
			this.municipioTextBox.Size = new System.Drawing.Size(272, 20);
			this.municipioTextBox.TabIndex = 19;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 172);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(52, 13);
			this.label12.TabIndex = 18;
			this.label12.Text = "Municipio";
			// 
			// cnaePrimarioTextBox
			// 
			this.cnaePrimarioTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.cnaePrimarioTextBox.Location = new System.Drawing.Point(299, 71);
			this.cnaePrimarioTextBox.Name = "cnaePrimarioTextBox";
			this.cnaePrimarioTextBox.ReadOnly = true;
			this.cnaePrimarioTextBox.Size = new System.Drawing.Size(326, 20);
			this.cnaePrimarioTextBox.TabIndex = 17;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(296, 55);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(76, 13);
			this.label11.TabIndex = 16;
			this.label11.Text = "CNAE Primário";
			// 
			// bairroTextBox
			// 
			this.bairroTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.bairroTextBox.Location = new System.Drawing.Point(345, 149);
			this.bairroTextBox.Name = "bairroTextBox";
			this.bairroTextBox.ReadOnly = true;
			this.bairroTextBox.Size = new System.Drawing.Size(280, 20);
			this.bairroTextBox.TabIndex = 15;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(342, 133);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "Bairro";
			// 
			// complementoTextBox
			// 
			this.complementoTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.complementoTextBox.Location = new System.Drawing.Point(9, 149);
			this.complementoTextBox.Name = "complementoTextBox";
			this.complementoTextBox.ReadOnly = true;
			this.complementoTextBox.Size = new System.Drawing.Size(330, 20);
			this.complementoTextBox.TabIndex = 13;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 133);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "Complemento";
			// 
			// numeroTextBox
			// 
			this.numeroTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.numeroTextBox.Location = new System.Drawing.Point(549, 110);
			this.numeroTextBox.Name = "numeroTextBox";
			this.numeroTextBox.ReadOnly = true;
			this.numeroTextBox.Size = new System.Drawing.Size(76, 20);
			this.numeroTextBox.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(546, 94);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "Número";
			// 
			// logradouroTextBox
			// 
			this.logradouroTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.logradouroTextBox.Location = new System.Drawing.Point(9, 110);
			this.logradouroTextBox.Name = "logradouroTextBox";
			this.logradouroTextBox.ReadOnly = true;
			this.logradouroTextBox.Size = new System.Drawing.Size(534, 20);
			this.logradouroTextBox.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 94);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Logradouro";
			// 
			// nomeFantasiaTextBox
			// 
			this.nomeFantasiaTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.nomeFantasiaTextBox.Location = new System.Drawing.Point(9, 71);
			this.nomeFantasiaTextBox.Name = "nomeFantasiaTextBox";
			this.nomeFantasiaTextBox.ReadOnly = true;
			this.nomeFantasiaTextBox.Size = new System.Drawing.Size(284, 20);
			this.nomeFantasiaTextBox.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Nome Fantasia";
			// 
			// dataAberturaTextBox
			// 
			this.dataAberturaTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.dataAberturaTextBox.Location = new System.Drawing.Point(512, 32);
			this.dataAberturaTextBox.Name = "dataAberturaTextBox";
			this.dataAberturaTextBox.ReadOnly = true;
			this.dataAberturaTextBox.Size = new System.Drawing.Size(113, 20);
			this.dataAberturaTextBox.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(509, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Abertura";
			// 
			// razaoSocialTextBox
			// 
			this.razaoSocialTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.razaoSocialTextBox.Location = new System.Drawing.Point(111, 32);
			this.razaoSocialTextBox.Name = "razaoSocialTextBox";
			this.razaoSocialTextBox.ReadOnly = true;
			this.razaoSocialTextBox.Size = new System.Drawing.Size(395, 20);
			this.razaoSocialTextBox.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(108, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Razão Social";
			// 
			// tipoEmpresaTextBox
			// 
			this.tipoEmpresaTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.tipoEmpresaTextBox.Location = new System.Drawing.Point(9, 32);
			this.tipoEmpresaTextBox.Name = "tipoEmpresaTextBox";
			this.tipoEmpresaTextBox.ReadOnly = true;
			this.tipoEmpresaTextBox.Size = new System.Drawing.Size(96, 20);
			this.tipoEmpresaTextBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tipo Empresa";
			// 
			// consultaTabControl
			// 
			this.consultaTabControl.Controls.Add(this.cnpjTabPage);
			this.consultaTabControl.Controls.Add(this.cpfTabPage);
			this.consultaTabControl.Controls.Add(this.sintegraTabPage);
			this.consultaTabControl.Controls.Add(this.ibgeTabPage);
			this.consultaTabControl.Controls.Add(this.cepTabPage);
			this.consultaTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.consultaTabControl.Location = new System.Drawing.Point(0, 0);
			this.consultaTabControl.Name = "consultaTabControl";
			this.consultaTabControl.SelectedIndex = 0;
			this.consultaTabControl.Size = new System.Drawing.Size(655, 537);
			this.consultaTabControl.TabIndex = 8;
			// 
			// cnpjTabPage
			// 
			this.cnpjTabPage.Controls.Add(this.groupBox1);
			this.cnpjTabPage.Controls.Add(this.procurarCnpjButton);
			this.cnpjTabPage.Controls.Add(this.cnpjMaskedTextBox);
			this.cnpjTabPage.Controls.Add(this.label1);
			this.cnpjTabPage.Location = new System.Drawing.Point(4, 22);
			this.cnpjTabPage.Name = "cnpjTabPage";
			this.cnpjTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.cnpjTabPage.Size = new System.Drawing.Size(647, 511);
			this.cnpjTabPage.TabIndex = 0;
			this.cnpjTabPage.Text = "CNPJ";
			this.cnpjTabPage.UseVisualStyleBackColor = true;
			// 
			// procurarCnpjButton
			// 
			this.procurarCnpjButton.Location = new System.Drawing.Point(287, 23);
			this.procurarCnpjButton.Name = "procurarCnpjButton";
			this.procurarCnpjButton.Size = new System.Drawing.Size(94, 38);
			this.procurarCnpjButton.TabIndex = 0;
			this.procurarCnpjButton.Text = "Procurar";
			this.procurarCnpjButton.UseVisualStyleBackColor = true;
			this.procurarCnpjButton.Click += new System.EventHandler(this.procurarCnpjButton_Click);
			// 
			// cpfTabPage
			// 
			this.cpfTabPage.Controls.Add(this.dataNascimentoMaskedTextBox);
			this.cpfTabPage.Controls.Add(this.groupBox2);
			this.cpfTabPage.Controls.Add(this.label20);
			this.cpfTabPage.Controls.Add(this.procurarCpfButton);
			this.cpfTabPage.Controls.Add(this.cpfMaskedTextBox);
			this.cpfTabPage.Controls.Add(this.label19);
			this.cpfTabPage.Location = new System.Drawing.Point(4, 22);
			this.cpfTabPage.Name = "cpfTabPage";
			this.cpfTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.cpfTabPage.Size = new System.Drawing.Size(647, 511);
			this.cpfTabPage.TabIndex = 1;
			this.cpfTabPage.Text = "CPF";
			this.cpfTabPage.UseVisualStyleBackColor = true;
			// 
			// dataNascimentoMaskedTextBox
			// 
			this.dataNascimentoMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataNascimentoMaskedTextBox.Location = new System.Drawing.Point(288, 19);
			this.dataNascimentoMaskedTextBox.Mask = "00/00/0000";
			this.dataNascimentoMaskedTextBox.Name = "dataNascimentoMaskedTextBox";
			this.dataNascimentoMaskedTextBox.Size = new System.Drawing.Size(173, 38);
			this.dataNascimentoMaskedTextBox.TabIndex = 3;
			this.dataNascimentoMaskedTextBox.ValidatingType = typeof(System.DateTime);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.codControleTextBox);
			this.groupBox2.Controls.Add(this.label26);
			this.groupBox2.Controls.Add(this.comprovanteTextBox);
			this.groupBox2.Controls.Add(this.label25);
			this.groupBox2.Controls.Add(this.digitoTextBox);
			this.groupBox2.Controls.Add(this.label24);
			this.groupBox2.Controls.Add(this.dataInscricaoTextBox);
			this.groupBox2.Controls.Add(this.label23);
			this.groupBox2.Controls.Add(this.situacaoCpfTextBox);
			this.groupBox2.Controls.Add(this.label22);
			this.groupBox2.Controls.Add(this.nomeTextBox);
			this.groupBox2.Controls.Add(this.label21);
			this.groupBox2.Location = new System.Drawing.Point(10, 63);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(631, 440);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			// 
			// codControleTextBox
			// 
			this.codControleTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.codControleTextBox.Location = new System.Drawing.Point(9, 110);
			this.codControleTextBox.Name = "codControleTextBox";
			this.codControleTextBox.ReadOnly = true;
			this.codControleTextBox.Size = new System.Drawing.Size(616, 20);
			this.codControleTextBox.TabIndex = 35;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(6, 94);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(179, 13);
			this.label26.TabIndex = 34;
			this.label26.Text = "Código de controle do comprovante:";
			// 
			// comprovanteTextBox
			// 
			this.comprovanteTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.comprovanteTextBox.Location = new System.Drawing.Point(108, 71);
			this.comprovanteTextBox.Name = "comprovanteTextBox";
			this.comprovanteTextBox.ReadOnly = true;
			this.comprovanteTextBox.Size = new System.Drawing.Size(320, 20);
			this.comprovanteTextBox.TabIndex = 33;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(105, 55);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(123, 13);
			this.label25.TabIndex = 32;
			this.label25.Text = "Comprovante emitido às:";
			// 
			// digitoTextBox
			// 
			this.digitoTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.digitoTextBox.Location = new System.Drawing.Point(9, 71);
			this.digitoTextBox.Name = "digitoTextBox";
			this.digitoTextBox.ReadOnly = true;
			this.digitoTextBox.Size = new System.Drawing.Size(93, 20);
			this.digitoTextBox.TabIndex = 31;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(6, 55);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(87, 13);
			this.label24.TabIndex = 30;
			this.label24.Text = "Digito Verificador";
			// 
			// dataInscricaoTextBox
			// 
			this.dataInscricaoTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.dataInscricaoTextBox.Location = new System.Drawing.Point(434, 71);
			this.dataInscricaoTextBox.Name = "dataInscricaoTextBox";
			this.dataInscricaoTextBox.ReadOnly = true;
			this.dataInscricaoTextBox.Size = new System.Drawing.Size(191, 20);
			this.dataInscricaoTextBox.TabIndex = 29;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(431, 55);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(86, 13);
			this.label23.TabIndex = 28;
			this.label23.Text = "Data da Incrição";
			// 
			// situacaoCpfTextBox
			// 
			this.situacaoCpfTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.situacaoCpfTextBox.Location = new System.Drawing.Point(434, 32);
			this.situacaoCpfTextBox.Name = "situacaoCpfTextBox";
			this.situacaoCpfTextBox.ReadOnly = true;
			this.situacaoCpfTextBox.Size = new System.Drawing.Size(191, 20);
			this.situacaoCpfTextBox.TabIndex = 27;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(431, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(96, 13);
			this.label22.TabIndex = 26;
			this.label22.Text = "Situação Cadastral";
			// 
			// nomeTextBox
			// 
			this.nomeTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.nomeTextBox.Location = new System.Drawing.Point(9, 32);
			this.nomeTextBox.Name = "nomeTextBox";
			this.nomeTextBox.ReadOnly = true;
			this.nomeTextBox.Size = new System.Drawing.Size(419, 20);
			this.nomeTextBox.TabIndex = 5;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(6, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(120, 13);
			this.label21.TabIndex = 4;
			this.label21.Text = "Nome da Pessoa Física";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(288, 3);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(152, 13);
			this.label20.TabIndex = 14;
			this.label20.Text = "Digite o a Data de Nascimento";
			// 
			// procurarCpfButton
			// 
			this.procurarCpfButton.Location = new System.Drawing.Point(467, 19);
			this.procurarCpfButton.Name = "procurarCpfButton";
			this.procurarCpfButton.Size = new System.Drawing.Size(94, 38);
			this.procurarCpfButton.TabIndex = 5;
			this.procurarCpfButton.Text = "Procurar";
			this.procurarCpfButton.UseVisualStyleBackColor = true;
			this.procurarCpfButton.Click += new System.EventHandler(this.procurarCpfButton_Click);
			// 
			// cpfMaskedTextBox
			// 
			this.cpfMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cpfMaskedTextBox.Location = new System.Drawing.Point(9, 19);
			this.cpfMaskedTextBox.Mask = "000.000.000-00";
			this.cpfMaskedTextBox.Name = "cpfMaskedTextBox";
			this.cpfMaskedTextBox.Size = new System.Drawing.Size(273, 38);
			this.cpfMaskedTextBox.TabIndex = 2;
			this.cpfMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(6, 3);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(66, 13);
			this.label19.TabIndex = 10;
			this.label19.Text = "Digite o CPF";
			// 
			// sintegraTabPage
			// 
			this.sintegraTabPage.Controls.Add(this.label49);
			this.sintegraTabPage.Controls.Add(this.label48);
			this.sintegraTabPage.Controls.Add(this.inscricaoSintegraTextBox);
			this.sintegraTabPage.Controls.Add(this.ufSintegraComboBox);
			this.sintegraTabPage.Controls.Add(this.groupBox9);
			this.sintegraTabPage.Controls.Add(this.procurarSintegraCnpjButton);
			this.sintegraTabPage.Controls.Add(this.cnpjSintegraMaskedTextBox);
			this.sintegraTabPage.Controls.Add(this.label47);
			this.sintegraTabPage.Location = new System.Drawing.Point(4, 22);
			this.sintegraTabPage.Name = "sintegraTabPage";
			this.sintegraTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.sintegraTabPage.Size = new System.Drawing.Size(647, 511);
			this.sintegraTabPage.TabIndex = 4;
			this.sintegraTabPage.Text = "Sintegra";
			this.sintegraTabPage.UseVisualStyleBackColor = true;
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(5, 7);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(40, 13);
			this.label49.TabIndex = 15;
			this.label49.Text = "Estado";
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.Location = new System.Drawing.Point(253, 7);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(133, 13);
			this.label48.TabIndex = 14;
			this.label48.Text = "Digite a Inscrição Estadual";
			// 
			// inscricaoSintegraTextBox
			// 
			this.inscricaoSintegraTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inscricaoSintegraTextBox.Location = new System.Drawing.Point(253, 23);
			this.inscricaoSintegraTextBox.Name = "inscricaoSintegraTextBox";
			this.inscricaoSintegraTextBox.Size = new System.Drawing.Size(185, 26);
			this.inscricaoSintegraTextBox.TabIndex = 13;
			// 
			// ufSintegraComboBox
			// 
			this.ufSintegraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ufSintegraComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ufSintegraComboBox.FormattingEnabled = true;
			this.ufSintegraComboBox.Location = new System.Drawing.Point(8, 23);
			this.ufSintegraComboBox.Name = "ufSintegraComboBox";
			this.ufSintegraComboBox.Size = new System.Drawing.Size(77, 26);
			this.ufSintegraComboBox.TabIndex = 12;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.situacaoSintegraTextBox);
			this.groupBox9.Controls.Add(this.label34);
			this.groupBox9.Controls.Add(this.cepSintegraTextBox);
			this.groupBox9.Controls.Add(this.label35);
			this.groupBox9.Controls.Add(this.ufSintegraTextBox);
			this.groupBox9.Controls.Add(this.label36);
			this.groupBox9.Controls.Add(this.municipioSintegraTextBox);
			this.groupBox9.Controls.Add(this.label37);
			this.groupBox9.Controls.Add(this.ieSintegraTextBox);
			this.groupBox9.Controls.Add(this.label38);
			this.groupBox9.Controls.Add(this.bairroSintegraTextBox);
			this.groupBox9.Controls.Add(this.label39);
			this.groupBox9.Controls.Add(this.complementoSintegraTextBox);
			this.groupBox9.Controls.Add(this.label40);
			this.groupBox9.Controls.Add(this.numeroSintegraTextBox);
			this.groupBox9.Controls.Add(this.label41);
			this.groupBox9.Controls.Add(this.logradouroSintegraTextBox);
			this.groupBox9.Controls.Add(this.label42);
			this.groupBox9.Controls.Add(this.cnpjSintegraTextBox);
			this.groupBox9.Controls.Add(this.label43);
			this.groupBox9.Controls.Add(this.dataAberturaSintegraTextBox);
			this.groupBox9.Controls.Add(this.label44);
			this.groupBox9.Controls.Add(this.razaoSocialSintegraTextBox);
			this.groupBox9.Controls.Add(this.label45);
			this.groupBox9.Location = new System.Drawing.Point(8, 61);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(631, 442);
			this.groupBox9.TabIndex = 11;
			this.groupBox9.TabStop = false;
			// 
			// situacaoSintegraTextBox
			// 
			this.situacaoSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.situacaoSintegraTextBox.Location = new System.Drawing.Point(434, 188);
			this.situacaoSintegraTextBox.Name = "situacaoSintegraTextBox";
			this.situacaoSintegraTextBox.ReadOnly = true;
			this.situacaoSintegraTextBox.Size = new System.Drawing.Size(191, 20);
			this.situacaoSintegraTextBox.TabIndex = 25;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(431, 172);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(96, 13);
			this.label34.TabIndex = 24;
			this.label34.Text = "Situação Cadastral";
			// 
			// cepSintegraTextBox
			// 
			this.cepSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.cepSintegraTextBox.Location = new System.Drawing.Point(324, 188);
			this.cepSintegraTextBox.Name = "cepSintegraTextBox";
			this.cepSintegraTextBox.ReadOnly = true;
			this.cepSintegraTextBox.Size = new System.Drawing.Size(104, 20);
			this.cepSintegraTextBox.TabIndex = 23;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(321, 172);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(28, 13);
			this.label35.TabIndex = 22;
			this.label35.Text = "CEP";
			// 
			// ufSintegraTextBox
			// 
			this.ufSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.ufSintegraTextBox.Location = new System.Drawing.Point(287, 188);
			this.ufSintegraTextBox.Name = "ufSintegraTextBox";
			this.ufSintegraTextBox.ReadOnly = true;
			this.ufSintegraTextBox.Size = new System.Drawing.Size(31, 20);
			this.ufSintegraTextBox.TabIndex = 21;
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(284, 172);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(21, 13);
			this.label36.TabIndex = 20;
			this.label36.Text = "UF";
			// 
			// municipioSintegraTextBox
			// 
			this.municipioSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.municipioSintegraTextBox.Location = new System.Drawing.Point(9, 188);
			this.municipioSintegraTextBox.Name = "municipioSintegraTextBox";
			this.municipioSintegraTextBox.ReadOnly = true;
			this.municipioSintegraTextBox.Size = new System.Drawing.Size(272, 20);
			this.municipioSintegraTextBox.TabIndex = 19;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(6, 172);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(52, 13);
			this.label37.TabIndex = 18;
			this.label37.Text = "Municipio";
			// 
			// ieSintegraTextBox
			// 
			this.ieSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.ieSintegraTextBox.Location = new System.Drawing.Point(299, 71);
			this.ieSintegraTextBox.Name = "ieSintegraTextBox";
			this.ieSintegraTextBox.ReadOnly = true;
			this.ieSintegraTextBox.Size = new System.Drawing.Size(326, 20);
			this.ieSintegraTextBox.TabIndex = 17;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(296, 55);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(94, 13);
			this.label38.TabIndex = 16;
			this.label38.Text = "Inscrição Estadual";
			// 
			// bairroSintegraTextBox
			// 
			this.bairroSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.bairroSintegraTextBox.Location = new System.Drawing.Point(345, 149);
			this.bairroSintegraTextBox.Name = "bairroSintegraTextBox";
			this.bairroSintegraTextBox.ReadOnly = true;
			this.bairroSintegraTextBox.Size = new System.Drawing.Size(280, 20);
			this.bairroSintegraTextBox.TabIndex = 15;
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(342, 133);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(34, 13);
			this.label39.TabIndex = 14;
			this.label39.Text = "Bairro";
			// 
			// complementoSintegraTextBox
			// 
			this.complementoSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.complementoSintegraTextBox.Location = new System.Drawing.Point(9, 149);
			this.complementoSintegraTextBox.Name = "complementoSintegraTextBox";
			this.complementoSintegraTextBox.ReadOnly = true;
			this.complementoSintegraTextBox.Size = new System.Drawing.Size(330, 20);
			this.complementoSintegraTextBox.TabIndex = 13;
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(6, 133);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(71, 13);
			this.label40.TabIndex = 12;
			this.label40.Text = "Complemento";
			// 
			// numeroSintegraTextBox
			// 
			this.numeroSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.numeroSintegraTextBox.Location = new System.Drawing.Point(549, 110);
			this.numeroSintegraTextBox.Name = "numeroSintegraTextBox";
			this.numeroSintegraTextBox.ReadOnly = true;
			this.numeroSintegraTextBox.Size = new System.Drawing.Size(76, 20);
			this.numeroSintegraTextBox.TabIndex = 11;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(546, 94);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(44, 13);
			this.label41.TabIndex = 10;
			this.label41.Text = "Número";
			// 
			// logradouroSintegraTextBox
			// 
			this.logradouroSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.logradouroSintegraTextBox.Location = new System.Drawing.Point(9, 110);
			this.logradouroSintegraTextBox.Name = "logradouroSintegraTextBox";
			this.logradouroSintegraTextBox.ReadOnly = true;
			this.logradouroSintegraTextBox.Size = new System.Drawing.Size(534, 20);
			this.logradouroSintegraTextBox.TabIndex = 9;
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(6, 94);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(61, 13);
			this.label42.TabIndex = 8;
			this.label42.Text = "Logradouro";
			// 
			// cnpjSintegraTextBox
			// 
			this.cnpjSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.cnpjSintegraTextBox.Location = new System.Drawing.Point(9, 71);
			this.cnpjSintegraTextBox.Name = "cnpjSintegraTextBox";
			this.cnpjSintegraTextBox.ReadOnly = true;
			this.cnpjSintegraTextBox.Size = new System.Drawing.Size(284, 20);
			this.cnpjSintegraTextBox.TabIndex = 7;
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(6, 55);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(34, 13);
			this.label43.TabIndex = 6;
			this.label43.Text = "CNPJ";
			// 
			// dataAberturaSintegraTextBox
			// 
			this.dataAberturaSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.dataAberturaSintegraTextBox.Location = new System.Drawing.Point(512, 32);
			this.dataAberturaSintegraTextBox.Name = "dataAberturaSintegraTextBox";
			this.dataAberturaSintegraTextBox.ReadOnly = true;
			this.dataAberturaSintegraTextBox.Size = new System.Drawing.Size(113, 20);
			this.dataAberturaSintegraTextBox.TabIndex = 5;
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(509, 16);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(47, 13);
			this.label44.TabIndex = 4;
			this.label44.Text = "Abertura";
			// 
			// razaoSocialSintegraTextBox
			// 
			this.razaoSocialSintegraTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.razaoSocialSintegraTextBox.Location = new System.Drawing.Point(9, 32);
			this.razaoSocialSintegraTextBox.Name = "razaoSocialSintegraTextBox";
			this.razaoSocialSintegraTextBox.ReadOnly = true;
			this.razaoSocialSintegraTextBox.Size = new System.Drawing.Size(497, 20);
			this.razaoSocialSintegraTextBox.TabIndex = 3;
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(6, 16);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(70, 13);
			this.label45.TabIndex = 2;
			this.label45.Text = "Razão Social";
			// 
			// procurarSintegraCnpjButton
			// 
			this.procurarSintegraCnpjButton.Location = new System.Drawing.Point(444, 17);
			this.procurarSintegraCnpjButton.Name = "procurarSintegraCnpjButton";
			this.procurarSintegraCnpjButton.Size = new System.Drawing.Size(94, 38);
			this.procurarSintegraCnpjButton.TabIndex = 8;
			this.procurarSintegraCnpjButton.Text = "Procurar";
			this.procurarSintegraCnpjButton.UseVisualStyleBackColor = true;
			this.procurarSintegraCnpjButton.Click += new System.EventHandler(this.procurarSintegraCnpjButton_Click);
			// 
			// cnpjSintegraMaskedTextBox
			// 
			this.cnpjSintegraMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cnpjSintegraMaskedTextBox.Location = new System.Drawing.Point(91, 23);
			this.cnpjSintegraMaskedTextBox.Mask = "00.000.000\\/0000-00";
			this.cnpjSintegraMaskedTextBox.Name = "cnpjSintegraMaskedTextBox";
			this.cnpjSintegraMaskedTextBox.Size = new System.Drawing.Size(156, 26);
			this.cnpjSintegraMaskedTextBox.TabIndex = 9;
			this.cnpjSintegraMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(88, 7);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(73, 13);
			this.label47.TabIndex = 10;
			this.label47.Text = "Digite o CNPJ";
			// 
			// ibgeTabPage
			// 
			this.ibgeTabPage.Controls.Add(this.groupBox5);
			this.ibgeTabPage.Controls.Add(this.groupBox4);
			this.ibgeTabPage.Controls.Add(this.groupBox3);
			this.ibgeTabPage.Location = new System.Drawing.Point(4, 22);
			this.ibgeTabPage.Name = "ibgeTabPage";
			this.ibgeTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.ibgeTabPage.Size = new System.Drawing.Size(647, 511);
			this.ibgeTabPage.TabIndex = 2;
			this.ibgeTabPage.Text = "IBGE";
			this.ibgeTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.ibgeDataGridView);
			this.groupBox5.Location = new System.Drawing.Point(8, 103);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(631, 400);
			this.groupBox5.TabIndex = 20;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Resultados";
			// 
			// ibgeDataGridView
			// 
			this.ibgeDataGridView.AllowUserToAddRows = false;
			this.ibgeDataGridView.AllowUserToDeleteRows = false;
			this.ibgeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ibgeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ibgeDataGridView.Location = new System.Drawing.Point(3, 16);
			this.ibgeDataGridView.Name = "ibgeDataGridView";
			this.ibgeDataGridView.ReadOnly = true;
			this.ibgeDataGridView.Size = new System.Drawing.Size(625, 381);
			this.ibgeDataGridView.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.procurarIbgeNomeButton);
			this.groupBox4.Controls.Add(this.label27);
			this.groupBox4.Controls.Add(this.nomeIbgeTextBox);
			this.groupBox4.Location = new System.Drawing.Point(185, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(454, 91);
			this.groupBox4.TabIndex = 19;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Por Nome";
			// 
			// procurarIbgeNomeButton
			// 
			this.procurarIbgeNomeButton.Location = new System.Drawing.Point(373, 62);
			this.procurarIbgeNomeButton.Name = "procurarIbgeNomeButton";
			this.procurarIbgeNomeButton.Size = new System.Drawing.Size(75, 23);
			this.procurarIbgeNomeButton.TabIndex = 21;
			this.procurarIbgeNomeButton.Text = "Procurar";
			this.procurarIbgeNomeButton.UseVisualStyleBackColor = true;
			this.procurarIbgeNomeButton.Click += new System.EventHandler(this.procurarIbgeNomeButton_Click);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(6, 20);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(134, 13);
			this.label27.TabIndex = 13;
			this.label27.Text = "Digite o nome do municipio";
			// 
			// nomeIbgeTextBox
			// 
			this.nomeIbgeTextBox.Location = new System.Drawing.Point(6, 36);
			this.nomeIbgeTextBox.Name = "nomeIbgeTextBox";
			this.nomeIbgeTextBox.Size = new System.Drawing.Size(442, 20);
			this.nomeIbgeTextBox.TabIndex = 14;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.procurarIbgeCodigoButton);
			this.groupBox3.Controls.Add(this.codigoIbgeTextBox);
			this.groupBox3.Controls.Add(this.label28);
			this.groupBox3.Location = new System.Drawing.Point(8, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(171, 91);
			this.groupBox3.TabIndex = 18;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Por Código";
			// 
			// procurarIbgeCodigoButton
			// 
			this.procurarIbgeCodigoButton.Location = new System.Drawing.Point(90, 62);
			this.procurarIbgeCodigoButton.Name = "procurarIbgeCodigoButton";
			this.procurarIbgeCodigoButton.Size = new System.Drawing.Size(75, 23);
			this.procurarIbgeCodigoButton.TabIndex = 20;
			this.procurarIbgeCodigoButton.Text = "Procurar";
			this.procurarIbgeCodigoButton.UseVisualStyleBackColor = true;
			this.procurarIbgeCodigoButton.Click += new System.EventHandler(this.procurarIbgeCodigoButton_Click);
			// 
			// codigoIbgeTextBox
			// 
			this.codigoIbgeTextBox.Location = new System.Drawing.Point(6, 36);
			this.codigoIbgeTextBox.Name = "codigoIbgeTextBox";
			this.codigoIbgeTextBox.Size = new System.Drawing.Size(159, 20);
			this.codigoIbgeTextBox.TabIndex = 16;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(3, 20);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(140, 13);
			this.label28.TabIndex = 15;
			this.label28.Text = "Digite o código do municipio";
			// 
			// cepTabPage
			// 
			this.cepTabPage.Controls.Add(this.cepTabControl);
			this.cepTabPage.Controls.Add(this.groupBox6);
			this.cepTabPage.Location = new System.Drawing.Point(4, 22);
			this.cepTabPage.Name = "cepTabPage";
			this.cepTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.cepTabPage.Size = new System.Drawing.Size(647, 511);
			this.cepTabPage.TabIndex = 3;
			this.cepTabPage.Text = "CEP";
			this.cepTabPage.UseVisualStyleBackColor = true;
			// 
			// cepTabControl
			// 
			this.cepTabControl.Controls.Add(this.configuraCepTabPage);
			this.cepTabControl.Controls.Add(this.consultaCepTabPage);
			this.cepTabControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.cepTabControl.Location = new System.Drawing.Point(3, 3);
			this.cepTabControl.Name = "cepTabControl";
			this.cepTabControl.SelectedIndex = 0;
			this.cepTabControl.Size = new System.Drawing.Size(641, 131);
			this.cepTabControl.TabIndex = 26;
			// 
			// configuraCepTabPage
			// 
			this.configuraCepTabPage.Controls.Add(this.label31);
			this.configuraCepTabPage.Controls.Add(this.webserviceCepComboBox);
			this.configuraCepTabPage.Location = new System.Drawing.Point(4, 22);
			this.configuraCepTabPage.Name = "configuraCepTabPage";
			this.configuraCepTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.configuraCepTabPage.Size = new System.Drawing.Size(633, 105);
			this.configuraCepTabPage.TabIndex = 0;
			this.configuraCepTabPage.Text = "Configurações";
			this.configuraCepTabPage.UseVisualStyleBackColor = true;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(6, 7);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(123, 13);
			this.label31.TabIndex = 16;
			this.label31.Text = "Selecione o Webservice";
			// 
			// webserviceCepComboBox
			// 
			this.webserviceCepComboBox.FormattingEnabled = true;
			this.webserviceCepComboBox.Location = new System.Drawing.Point(9, 23);
			this.webserviceCepComboBox.Name = "webserviceCepComboBox";
			this.webserviceCepComboBox.Size = new System.Drawing.Size(121, 21);
			this.webserviceCepComboBox.TabIndex = 0;
			this.webserviceCepComboBox.SelectedIndexChanged += new System.EventHandler(this.webserviceCepComboBox_SelectedIndexChanged);
			// 
			// consultaCepTabPage
			// 
			this.consultaCepTabPage.Controls.Add(this.groupBox8);
			this.consultaCepTabPage.Controls.Add(this.groupBox7);
			this.consultaCepTabPage.Location = new System.Drawing.Point(4, 22);
			this.consultaCepTabPage.Name = "consultaCepTabPage";
			this.consultaCepTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.consultaCepTabPage.Size = new System.Drawing.Size(633, 105);
			this.consultaCepTabPage.TabIndex = 1;
			this.consultaCepTabPage.Text = "Consulta CEP";
			this.consultaCepTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.buscaCepButton);
			this.groupBox8.Controls.Add(this.cepTextBox);
			this.groupBox8.Controls.Add(this.label18);
			this.groupBox8.Location = new System.Drawing.Point(6, 6);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(95, 91);
			this.groupBox8.TabIndex = 24;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Por CEP";
			// 
			// buscaCepButton
			// 
			this.buscaCepButton.Location = new System.Drawing.Point(12, 62);
			this.buscaCepButton.Name = "buscaCepButton";
			this.buscaCepButton.Size = new System.Drawing.Size(75, 23);
			this.buscaCepButton.TabIndex = 20;
			this.buscaCepButton.Text = "Procurar";
			this.buscaCepButton.UseVisualStyleBackColor = true;
			this.buscaCepButton.Click += new System.EventHandler(this.buscaCepButton_Click);
			// 
			// cepTextBox
			// 
			this.cepTextBox.Location = new System.Drawing.Point(6, 36);
			this.cepTextBox.Name = "cepTextBox";
			this.cepTextBox.Size = new System.Drawing.Size(81, 20);
			this.cepTextBox.TabIndex = 16;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(3, 20);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(67, 13);
			this.label18.TabIndex = 15;
			this.label18.Text = "Digite o CEP";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label30);
			this.groupBox7.Controls.Add(this.logradouroCepTextBox);
			this.groupBox7.Controls.Add(this.label29);
			this.groupBox7.Controls.Add(this.ufCepComboBox);
			this.groupBox7.Controls.Add(this.buscaLogradouroButton);
			this.groupBox7.Controls.Add(this.label2);
			this.groupBox7.Controls.Add(this.municipioCepTextBox);
			this.groupBox7.Location = new System.Drawing.Point(107, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(520, 91);
			this.groupBox7.TabIndex = 25;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Por Nome";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(234, 19);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(96, 13);
			this.label30.TabIndex = 24;
			this.label30.Text = "Digite o logradouro";
			// 
			// logradouroCepTextBox
			// 
			this.logradouroCepTextBox.Location = new System.Drawing.Point(237, 35);
			this.logradouroCepTextBox.Name = "logradouroCepTextBox";
			this.logradouroCepTextBox.Size = new System.Drawing.Size(277, 20);
			this.logradouroCepTextBox.TabIndex = 25;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(3, 19);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(21, 13);
			this.label29.TabIndex = 23;
			this.label29.Text = "UF";
			// 
			// ufCepComboBox
			// 
			this.ufCepComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ufCepComboBox.FormattingEnabled = true;
			this.ufCepComboBox.Location = new System.Drawing.Point(6, 35);
			this.ufCepComboBox.Name = "ufCepComboBox";
			this.ufCepComboBox.Size = new System.Drawing.Size(60, 21);
			this.ufCepComboBox.TabIndex = 22;
			// 
			// buscaLogradouroButton
			// 
			this.buscaLogradouroButton.Location = new System.Drawing.Point(439, 61);
			this.buscaLogradouroButton.Name = "buscaLogradouroButton";
			this.buscaLogradouroButton.Size = new System.Drawing.Size(75, 23);
			this.buscaLogradouroButton.TabIndex = 21;
			this.buscaLogradouroButton.Text = "Procurar";
			this.buscaLogradouroButton.UseVisualStyleBackColor = true;
			this.buscaLogradouroButton.Click += new System.EventHandler(this.buscaLogradouroButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(69, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Digite o nome do municipio";
			// 
			// municipioCepTextBox
			// 
			this.municipioCepTextBox.Location = new System.Drawing.Point(72, 36);
			this.municipioCepTextBox.Name = "municipioCepTextBox";
			this.municipioCepTextBox.Size = new System.Drawing.Size(159, 20);
			this.municipioCepTextBox.TabIndex = 14;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cepDataGridView);
			this.groupBox6.Location = new System.Drawing.Point(6, 140);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(631, 363);
			this.groupBox6.TabIndex = 21;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Resultados";
			// 
			// cepDataGridView
			// 
			this.cepDataGridView.AllowUserToAddRows = false;
			this.cepDataGridView.AllowUserToDeleteRows = false;
			this.cepDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.cepDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cepDataGridView.Location = new System.Drawing.Point(3, 16);
			this.cepDataGridView.Name = "cepDataGridView";
			this.cepDataGridView.ReadOnly = true;
			this.cepDataGridView.Size = new System.Drawing.Size(625, 344);
			this.cepDataGridView.TabIndex = 0;
			// 
			// acbrCnpj
			// 
			this.acbrCnpj.OnGetCaptcha += new System.EventHandler<ACBr.Net.Consulta.CaptchaEventArgs>(this.acbrCnpj_OnGetCaptcha);
			// 
			// acbrCpf
			// 
			this.acbrCpf.OnGetCaptcha += new System.EventHandler<ACBr.Net.Consulta.CaptchaEventArgs>(this.acbrCpf_OnGetCaptcha);
			// 
			// acbrIbge
			// 
			this.acbrIbge.OnBuscaEfetuada += new System.EventHandler<System.EventArgs>(this.acbrIbge_OnBuscaEfetuada);
			// 
			// acbrCEP
			// 
			this.acbrCEP.ChaveAcesso = null;
			this.acbrCEP.PesquisarIBGE = false;
			this.acbrCEP.Senha = null;
			this.acbrCEP.Usuario = null;
			this.acbrCEP.WebService = ACBr.Net.Consulta.CEP.CEPWebService.Correios;
			this.acbrCEP.OnBuscaEfetuada += new System.EventHandler<System.EventArgs>(this.acbrCEP_OnBuscaEfetuada);
			// 
			// acbrConsultaSintegra
			// 
			this.acbrConsultaSintegra.OnGetCaptcha += new System.EventHandler<ACBr.Net.Consulta.CaptchaEventArgs>(this.acbrConsultaSintegra_OnGetCaptcha);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 537);
			this.Controls.Add(this.consultaTabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ACBr Consulta Demo";
			this.Shown += new System.EventHandler(this.FrmMain_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.consultaTabControl.ResumeLayout(false);
			this.cnpjTabPage.ResumeLayout(false);
			this.cnpjTabPage.PerformLayout();
			this.cpfTabPage.ResumeLayout(false);
			this.cpfTabPage.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.sintegraTabPage.ResumeLayout(false);
			this.sintegraTabPage.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.ibgeTabPage.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ibgeDataGridView)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.cepTabPage.ResumeLayout(false);
			this.cepTabControl.ResumeLayout(false);
			this.configuraCepTabPage.ResumeLayout(false);
			this.configuraCepTabPage.PerformLayout();
			this.consultaCepTabPage.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cepDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button procurarCnpjButton;
		private System.Windows.Forms.MaskedTextBox cnpjMaskedTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tipoEmpresaTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox dataAberturaTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox razaoSocialTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox numeroTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox logradouroTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox nomeFantasiaTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox cnaePrimarioTextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox bairroTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox complementoTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox situacaoTextBox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox cepCnpjTextBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox ufTextBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox municipioTextBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox cnaeSecundariosTextBox;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox naturezaJuridicaTextBox;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TabControl consultaTabControl;
		private System.Windows.Forms.TabPage cnpjTabPage;
		private System.Windows.Forms.TabPage cpfTabPage;
		private System.Windows.Forms.Button procurarCpfButton;
		private System.Windows.Forms.MaskedTextBox cpfMaskedTextBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox situacaoCpfTextBox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox nomeTextBox;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox codControleTextBox;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox comprovanteTextBox;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox digitoTextBox;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox dataInscricaoTextBox;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.MaskedTextBox dataNascimentoMaskedTextBox;
		private System.Windows.Forms.TabPage ibgeTabPage;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button procurarIbgeNomeButton;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox nomeIbgeTextBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button procurarIbgeCodigoButton;
		private System.Windows.Forms.TextBox codigoIbgeTextBox;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.DataGridView ibgeDataGridView;
		private ACBrConsultaCPF acbrCpf;
		private ACBrIBGE acbrIbge;
		private ACBrConsultaCNPJ acbrCnpj;
		private CEP.ACBrCEP acbrCEP;
		private Sintegra.ACBrConsultaSintegra acbrConsultaSintegra;
		private System.Windows.Forms.TabPage sintegraTabPage;
		private System.Windows.Forms.TabPage cepTabPage;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.DataGridView cepDataGridView;
		private System.Windows.Forms.TabControl cepTabControl;
		private System.Windows.Forms.TabPage configuraCepTabPage;
		private System.Windows.Forms.TabPage consultaCepTabPage;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button buscaCepButton;
		private System.Windows.Forms.TextBox cepTextBox;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox logradouroCepTextBox;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox ufCepComboBox;
		private System.Windows.Forms.Button buscaLogradouroButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox municipioCepTextBox;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.ComboBox webserviceCepComboBox;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox situacaoSintegraTextBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox cepSintegraTextBox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox ufSintegraTextBox;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox municipioSintegraTextBox;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox bairroSintegraTextBox;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox complementoSintegraTextBox;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox numeroSintegraTextBox;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox logradouroSintegraTextBox;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox dataAberturaSintegraTextBox;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox razaoSocialSintegraTextBox;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button procurarSintegraCnpjButton;
        private System.Windows.Forms.MaskedTextBox cnpjSintegraMaskedTextBox;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox inscricaoSintegraTextBox;
        private System.Windows.Forms.ComboBox ufSintegraComboBox;
        private System.Windows.Forms.TextBox ieSintegraTextBox;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox cnpjSintegraTextBox;
        private System.Windows.Forms.Label label43;
    }
}

