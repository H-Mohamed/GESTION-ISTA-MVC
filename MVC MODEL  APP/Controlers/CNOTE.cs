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
    class CNOTE
    {
        public static DataTable ALL()
        {
            return Controlers.DB.PROC_DS("getNotes").Tables[0];
        }
        public static void Ajouter(int CODEETUDIANT, int CODEMODULE, float Note, DataGridView d)
        {
            Controlers.DB.load_DGV(d,
            (Controlers.DB.PROC_DS_Params("ADDNOTE", new SqlParameter[]
            { new SqlParameter("@CODEE",CODEETUDIANT),
              new SqlParameter("@CODEM",CODEMODULE),
              new SqlParameter("@Note",Note)
            })).Tables[0]
            );
        }
        public static void Supprimer(int CE,int CM, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("DELNOTE", new SqlParameter[]
                    {   new SqlParameter("@CE",CE),
                        new SqlParameter("@CM",CE)
                    })).Tables[0]
                     );
            }
            catch
            {
                MessageBox.Show(CE + " > ne correspond à aucun enregistrement ");
            }
        }
        public static void Modifier(int CODEETUDIANT, int CODEMODULE, float Note, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("UPDNOTE", new SqlParameter[]
                    { new SqlParameter("@CE",CODEETUDIANT),
                      new SqlParameter("@CM",CODEMODULE),
                      new SqlParameter("@NOTE",Note)
                     })).Tables[0]
                );
            }
            catch
            {
                MessageBox.Show("("+CODEETUDIANT+","+ CODEMODULE+ ") > ne correspond à aucun enregistrement ");
            }
        }
        public static Models.Note Rechercher(int CODEET,int CODEMOD)
        {
            Models.Note e = new Models.Note();
            try
            {
                DataTable t = Controlers.DB.PROC_DS_Params("unenote", new SqlParameter[]
                {  new SqlParameter("@codee",CODEET),new SqlParameter("@codem",CODEMOD)
                }).Tables[0];
                if (t.Rows.Count != 0)
                    //instancier le Module trouvé
                    e = new Models.Note (int.Parse(t.Rows[0][0].ToString()),
                                         int.Parse(t.Rows[0][1].ToString()),
                                         float.Parse(t.Rows[0][2].ToString()));
                return e;
            }
            catch
            {
                return e;
            }
        }
    }
}
