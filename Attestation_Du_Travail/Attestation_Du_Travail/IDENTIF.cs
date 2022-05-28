using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Attestation_Du_Travail
{
    public partial class IDENTIF : Form
    {
        ADO ado = new ADO();
        int position = 0;
        public static string passingText;
        public IDENTIF()
        {
            InitializeComponent();
            DGV();
        }


        public void DGVPOSITION()
        {
            if (position > dataGridView1.Rows.Count - 1) { position = 0; return; }
            if (position < 0) { position = dataGridView1.Rows.Count - 1; return; }
        }

        public void SELECT_P()
        {
            dataGridView1.ClearSelection();
            dataGridView1.Rows[position].Selected = true;
        }

        public void DGV()
        {
            ado.DT.Clear();
            ado.DA = new SqlDataAdapter("select * from attestation_travail", ado.cn);
            ado.DA.Fill(ado.DT);
            dataGridView1.DataSource = ado.DT;

        }








        private void IDENTIF_Load(object sender, EventArgs e)
        {
            ado.connecter();
        }

        private void IDENTIF_Leave(object sender, EventArgs e)
        {
            ado.deconnecter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            position = dataGridView1.Rows.Count - 1; DGVPOSITION(); SELECT_P();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            position += 1; DGVPOSITION(); SELECT_P();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            position -= 1; DGVPOSITION(); SELECT_P();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            position = 0; DGVPOSITION(); SELECT_P();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            ado.DT.Clear();
            ado.DA = new SqlDataAdapter("select * from attestation_travail where CIN like '" + txt_search.Text + "%' or  PPR like '" + txt_search.Text + "%' or [NOM/PRENOM] like'" + txt_search.Text + "%'  ", ado.cn);
            ado.DA.Fill(ado.DT);
            dataGridView1.DataSource = ado.DT;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (passingText == "") { MessageBox.Show(" Vous Devez Selectionner Chaque Element Dans La Grid SVP !!"); }
            else
            {
                this.Hide();
                PRINT P = new PRINT();
                P.Show();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            passingText = dataGridView1.CurrentRow.Cells["CIN"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         if( MessageBox.Show("Voullez Vous Vraiement Quitter !! ", "Fermer ", MessageBoxButtons.OK,MessageBoxIcon.Question)==DialogResult.OK) {this.Close();}        
       }
    }
}