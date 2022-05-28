using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AttestaS;


namespace Attestation_Du_Travail
{
    public partial class PRINT : Form
    {
        ADO ado = new ADO();
        public PRINT()
        {
            InitializeComponent();
        }
        public void retour() 
        {
            this.Hide();
            IDENTIF id = new IDENTIF();
            id.Show();
        }

        private void PRINT_Load(object sender, EventArgs e)
        {
            txt_local.Focus();
       

        }

        private void button5_Click(object sender, EventArgs e)
        {

            ado.connecter();

            ado.cmd = new SqlCommand("update attestation_travail set LOCALE='"+ txt_local.Text+"' where CIN='" + IDENTIF.passingText + "'  ", ado.cn);
            

            if (txt_local.Text =="")
            {
                MessageBox.Show("Remplir Votre Zone Du Texte SVP !! مقـر العمـــــــل ", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Warning); txt_local.Focus();
            }
            else
            {
                ado.cmd.ExecuteNonQuery();

                ado.DT.Clear();
                ado.DA = new SqlDataAdapter("select * from attestation_travail where CIN='" + IDENTIF.passingText + "' ", ado.cn);

                ado.DA.Fill(ado.DT);



                CrystalReport1 cr1 = new CrystalReport1();
                cr1.SetDataSource(ado.DT);
                crystalReportViewer1.ReportSource = cr1;
                ado.deconnecter();

                button5.Enabled = false;
                txt_local.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            retour();
        }
    }
}
