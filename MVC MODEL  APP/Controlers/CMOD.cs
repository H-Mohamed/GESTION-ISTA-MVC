using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace MVC_MODEL__APP.Controlers
{
    class CMOD
    {
        public static DataTable ALL()
        {
            return Controlers.DB.PROC_DS("getModu").Tables[0];
        }
        public static void Ajouter(string CODEModule, string NOM, int codeProf, DateTime DATEP,
            DateTime DATER, DataGridView d)
        {
            Controlers.DB.load_DGV(d,
            (Controlers.DB.PROC_DS_Params("ADDMODULE", new SqlParameter[]
                    {  new SqlParameter("@CM",int.Parse(CODEModule)), new SqlParameter("@NOMM",NOM)
                     , new SqlParameter("@CP",codeProf), new SqlParameter("@DATEP",DATEP)
                     , new SqlParameter("@DATEP",DATER)
            })).Tables[0]
            );
        }
        public static void Supprimer(string CE, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("DELMOD", new SqlParameter[]
                    { new SqlParameter("@CE",CE) })).Tables[0]
                     );
            }
            catch
            {
                MessageBox.Show(CE + " > ne correspond à aucun enregistrement ");
            }
        }
        public static void Modifier(string CODEModule, string NOM, int codeProf, DateTime DATEP,
            DateTime DATER, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("UPDMOD", new SqlParameter[]
                    {  new SqlParameter("@CM",int.Parse(CODEModule)), new SqlParameter("@NOMM",NOM)
                     , new SqlParameter("@CP",codeProf), new SqlParameter("@DATEP",DATEP)
                     , new SqlParameter("@DATEP",DATER) 
                     })).Tables[0]
                );
            }
            catch
            {
                MessageBox.Show(CODEModule + " > ne correspond à aucun enregistrement ");
            }
        }
        public static Models.Module Rechercher(string CODEModule)
        {
            Models.Module e = new Models.Module();
            try
            {
                DataTable t = Controlers.DB.PROC_DS_Params("unmodule", new SqlParameter[]
                {  new SqlParameter("@codem",int.Parse(CODEModule))  }).Tables[0];
                if (t.Rows.Count != 0)
                    //instancier l'Etudiant trouvé
                    e = new Models.Module(int.Parse(t.Rows[0][0].ToString()),
                                        t.Rows[0][0].ToString(),
                                        int.Parse(t.Rows[0][0].ToString()),
                                        DateTime.Parse(t.Rows[0][0].ToString()),
                                        DateTime.Parse(t.Rows[0][0].ToString()));
                return e;
            }
            catch
            {
                return e;
            }
        }
    }
}
