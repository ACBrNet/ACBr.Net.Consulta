using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //10.588.548-7
        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://appasp.sefaz.go.gov.br/Sintegra/Consulta");
            HtmlDocument doc = webBrowser1.Document;
            webBrowser1.Document.GetElementById("tCCE").InnerText = "10.588.548-7";
            
        }
    }
}
