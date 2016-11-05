using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3(string ausentes, string letrasParaNumeros, string ruido)
        {
            InitializeComponent();
            AtualizaRichTextBox(ausentes, letrasParaNumeros, ruido);
        }
        private void AtualizaRichTextBox(string ausentes, string letrasParaNumeros, string ruido)
        {
            txtModificados.Text = "";
            if (ausentes != "")
            {
                txtModificados.Text += "Missing Attributes: \n\n";
                txtModificados.Text += ausentes;
                txtModificados.Text += "==================================";
            }
            if (letrasParaNumeros != "")
            {
                txtModificados.Text += "\n Modified Attributes: \n\n";
                txtModificados.Text += letrasParaNumeros;
                txtModificados.Text += "==================================";
            }
            if (ruido != "")
            {
                txtModificados.Text += "\n Noise: \n\n";
                txtModificados.Text += ruido;
            }

        }
    }
}
