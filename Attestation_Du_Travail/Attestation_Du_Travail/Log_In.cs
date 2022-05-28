using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Attestation_Du_Travail
{
    public partial class Log_In : Form
    {
       int cp=0;
        public Log_In()
        {
            InitializeComponent();
            txt_nom.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voullez Vous Vraiment Quitter !! ", "Fermer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text == "" || txt_password.Text == "") { MessageBox.Show(" VERIFIEZ SVP LES ZONES DU TEXTES EST VIDES !! ", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            else if (txt_nom.Text.ToUpper() == "USSEF" && txt_password.Text == "0000") { this.Hide(); IDENTIF ID = new IDENTIF(); ID.Show(); }

            else { MessageBox.Show(" VOTRE NOM ou PASSWORD INCORRECT VERIFIER SVP !!", "Verifier !!", MessageBoxButtons.OK, MessageBoxIcon.Error); txt_password.Clear(); txt_nom.Focus(); cp++; checkBox1.Checked = false; lb1.Text = cp.ToString(); }
            if (cp >= 3) { panel3.Enabled = false; button3.Hide(); }
        }

      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            txt_nom.Focus();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { txt_password.UseSystemPasswordChar = false; }
            else { txt_password.UseSystemPasswordChar = true; }
        }
    }
}
