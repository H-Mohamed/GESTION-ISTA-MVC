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
    class CPROF
    {
        public static DataTable ALL()
        {
            return Controlers.DB.PROC_DS("getProf").Tables[0];
        }
        public static void Ajouter(string CODEPROF, string NOM, string PRENOM, string Diplome,
              string EMAIL, DataGridView d)
        {
            Controlers.DB.load_DGV(d,
            (Controlers.DB.PROC_DS_Params("ADDPROF", new SqlParameter[]
            { new SqlParameter("@CODEPROF",CODEPROF), new SqlParameter("@CODEPROF",NOM)
            , new SqlParameter("@CODEPROF",PRENOM), new SqlParameter("@CODEPROF",Diplome)
            , new SqlParameter("@CODEPROF",EMAIL)
            })).Tables[0]
            );
        }
        public static void Supprimer(string CP, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("DELPROF", new SqlParameter[]
                    { new SqlParameter("@CP",CP) })).Tables[0]
                     );
            }
            catch
            {
                MessageBox.Show(CP + " > ne correspond à aucun enregistrement ");
            }
        }
        public static void Modifier(string CODEPROF, string NOM, string PRENOM, string DIPLOME,
            string EMAIL, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("UPDPROF", new SqlParameter[]
                    {  new SqlParameter("@CE",CODEPROF), new SqlParameter("@NOMPROF",NOM)
                     , new SqlParameter("@PRENOMPROF",PRENOM), new SqlParameter("@DIPLOMEPROF",DIPLOME)
                     , new SqlParameter("@EMAILPROF",EMAIL)
                     })).Tables[0]
                );
            }
            catch
            {
                MessageBox.Show(CODEPROF + " > ne correspond à aucun enregistrement ");
            }
        }
        public static Models.Professeur Rechercher(string CODEPROF)
        {
            Models.Professeur p = new Models.Professeur();
            try
            {
                DataTable t = Controlers.DB.PROC_DS_Params("unetudiant", new SqlParameter[]
                {  new SqlParameter("@codep",CODEPROF)  }).Tables[0];
                if (t.Rows.Count != 0)
                    //instancier le Professeur trouvé
                    p = new Models.Professeur(int.Parse(t.Rows[0][0].ToString()),
                                        t.Rows[0][1].ToString(),
                                        t.Rows[0][2].ToString(),
                                        t.Rows[0][3].ToString(),
                                        t.Rows[0][4].ToString());
                return p;
            }
            catch
            {
                return p;
            }
        }
    }
}
