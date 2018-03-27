using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MVC_MODEL__APP.Controlers
{
    class DB
    {
        public static SqlConnection Cnx =
        new SqlConnection (@"Data Source=HARIRMOHAMED\TDI201_2018;Initial Catalog"+
            "=DB_SAIR_Notes;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter da = new SqlDataAdapter();
        public static DataSet ds = new DataSet();
        #region Bindings & data processing
        public static void InitCMD(string command, CommandType T)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = command;
            cmd.CommandType = T;
            cmd.Connection = Cnx;
        }
        public static void PROC_NoDS_Params(string Proc, SqlParameter[] Params)
        {
            InitCMD(Proc, CommandType.StoredProcedure);
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(Params);
            cmd.ExecuteNonQuery();
        }
        public static DataSet PROC_DS(string Proc)
        {
            ds = new DataSet();
            InitCMD(Proc, CommandType.StoredProcedure);
            cmd.Parameters.Clear();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public static DataSet PROC_DS_Params(string Proc, SqlParameter[] Params)
        {
            try
            {
                InitCMD(Proc, CommandType.StoredProcedure);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(Params);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "T");
                return ds;
            }
            catch
            {
                return new DataSet();
            }
        }

        public static void load_DGV(DataGridView D, DataTable Table)//,BindingManagerBase b,string b_datamember)
        {
            try
            {
                // D.SelectionMode = SelectionMode.One;
                D = new DataGridView();
               // D.RowHeadersVisible = false;
                D.DataSource = Table;
                
                //  DataTable t = Table.Clone();
                //    b = BindingContext[t,b_datamember];
            }
            catch (Exception r)
            {
                error(r);
            }
        }
        #endregion
        private static void error(Exception t)
        {
            MessageBox.Show(t.Message + "\nDetails:" + t.TargetSite, "Erreur | " + t.TargetSite, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }
}
