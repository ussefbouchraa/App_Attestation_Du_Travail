using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Attestation_Du_Travail
{
    class ADO
    {
      

        public SqlConnection cn = new SqlConnection(@"workstation id=BASEUSSEF.mssql.somee.com;packet size=4096;user id=Q123_SQLLogin_1;pwd=8vvmdltkdb;data source=BASEUSSEF.mssql.somee.com;persist security info=False;initial catalog=BASEUSSEF");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter DA = new SqlDataAdapter();
        public SqlDataReader dr;
        public DataSet ds_xml = new DataSet();
        public DataSet ds1 = new DataSet();
        public DataTable DT = new DataTable();
        public SqlCommandBuilder SCB = new SqlCommandBuilder();
        public SqlTransaction tran;


        public void connecter()
        {
            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken) { cn.Open(); }

        }


        public void deconnecter()
        {
            if (cn.State == ConnectionState.Open || cn.State == ConnectionState.Broken) { cn.Close(); }

        }


    }
}
