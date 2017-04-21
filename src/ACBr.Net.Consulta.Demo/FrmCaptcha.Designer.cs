namespace ACBr.Net.Consulta.Demo
{
	partial class FrmCaptcha
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.captchaLinkLabel = new System.Windows.Forms.LinkLabel();
			this.captchaPictureBox = new System.Windows.Forms.PictureBox();
			this.enviarCaptchaButton = new System.Windows.Forms.Button();
			this.captchaTextBox = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.captchaPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.captchaLinkLabel);
			this.panel1.Controls.Add(this.captchaPictureBox);
			this.panel1.Location = new System.Drawing.Point(12, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(352, 117);
			this.panel1.TabIndex = 8;
			// 
			// captchaLinkLabel
			// 
			this.captchaLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.captchaLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captchaLinkLabel.Location = new System.Drawing.Point(0, 85);
			this.captchaLinkLabel.Name = "captchaLinkLabel";
			this.captchaLinkLabel.Size = new System.Drawing.Size(352, 32);
			this.captchaLinkLabel.TabIndex = 2;
			this.captchaLinkLabel.TabStop = true;
			this.captchaLinkLabel.Text = "Atualizar Captcha";
			this.captchaLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.captchaLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.captchaCnpjLinkLabel_LinkClicked);
			// 
			// captchaPictureBox
			// 
			this.captchaPictureBox.BackColor = System.Drawing.Color.White;
			this.captchaPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.captchaPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.captchaPictureBox.Location = new System.Drawing.Point(0, 0);
			this.captchaPictureBox.Name = "captchaPictureBox";
			this.captchaPictureBox.Size = new System.Drawing.Size(352, 85);
			this.captchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.captchaPictureBox.TabIndex = 1;
			this.captchaPictureBox.TabStop = false;
			// 
			// enviarCaptchaButton
			// 
			this.enviarCaptchaButton.Location = new System.Drawing.Point(270, 129);
			this.enviarCaptchaButton.Name = "enviarCaptchaButton";
			this.enviarCaptchaButton.Size = new System.Drawing.Size(94, 38);
			this.enviarCaptchaButton.TabIndex = 7;
			this.enviarCaptchaButton.Text = "Enviar";
			this.enviarCaptchaButton.UseVisualStyleBackColor = true;
			this.enviarCaptchaButton.Click += new System.EventHandler(this.enviarCaptchaButton_Click);
			// 
			// captchaTextBox
			// 
			this.captchaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captchaTextBox.Location = new System.Drawing.Point(12, 129);
			this.captchaTextBox.Name = "captchaTextBox";
			this.captchaTextBox.Size = new System.Drawing.Size(252, 38);
			this.captchaTextBox.TabIndex = 10;
			// 
			// FrmCaptcha
			// 
			this.AcceptButton = this.enviarCaptchaButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 179);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.enviarCaptchaButton);
			this.Controls.Add(this.captchaTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "FrmCaptcha";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Digite o Captcha";
			this.Shown += new System.EventHandler(this.FrmCaptcha_Shown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCaptcha_KeyUp);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.captchaPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel captchaLinkLabel;
		private System.Windows.Forms.PictureBox captchaPictureBox;
		private System.Windows.Forms.Button enviarCaptchaButton;
		private System.Windows.Forms.TextBox captchaTextBox;
	}
}