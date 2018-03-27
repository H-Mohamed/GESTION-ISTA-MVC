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
    class CETU
    {
        public static DataTable ALL()
        {
            return Controlers.DB.PROC_DS("getEtud").Tables[0];
        }
        public static void Ajouter(string CODEET, string NOM, string PRENOM, string DATEN,
            string EMAIL, DataGridView d)
        {
            Controlers.DB.load_DGV(d,
            (Controlers.DB.PROC_DS_Params("ADDETUD", new SqlParameter[]
            { new SqlParameter("@CODEET",CODEET), new SqlParameter("@NOM",NOM)
            , new SqlParameter("@PRENOM",PRENOM), new SqlParameter("@DATEN",DateTime.Parse(DATEN))
            , new SqlParameter("@EMAIL",EMAIL)
            })).Tables[0]
            ); 
        }
        public static void Supprimer(string CE, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("DELETD", new SqlParameter[]
                    { new SqlParameter("@CE",CE) })).Tables[0]
                     );
            }
            catch
            {
                MessageBox.Show(CE+ " > ne correspond à aucun enregistrement ");
            }
        }
        public static void Modifier(string CODEET, string NOM, string PRENOM, string DATEN,
            string EMAIL, DataGridView d)
        {
            try
            {
                Controlers.DB.load_DGV(
                    d,
                    (Controlers.DB.PROC_DS_Params("UPDETU", new SqlParameter[]
                    {  new SqlParameter("@CE",CODEET), new SqlParameter("@NOME",NOM)
                     , new SqlParameter("@PNOME",PRENOM), new SqlParameter("@DATEN",DateTime.Parse(DATEN))
                     , new SqlParameter("@EMAIL",EMAIL)
                     })).Tables[0]
                );
            }
            catch
            {
                MessageBox.Show(CODEET + " > ne correspond à aucun enregistrement ");
            }
        }
        public static Models.Etudiant Rechercher(int CODEET)
        {
            Models.Etudiant e = new Models.Etudiant();
            try
            {
                DataTable t = Controlers.DB.PROC_DS_Params("unetudiant", new SqlParameter[]
                {  new SqlParameter("@codee",CODEET)  }).Tables[0];
                if(t.Rows.Count!=0)
                    //instancier l'Etudiant trouvé
                    e = new Models.Etudiant(int.Parse(t.Rows[0][0].ToString()),
                                        t.Rows[0][1].ToString(),
                                        t.Rows[0][2].ToString(),
                                        DateTime.Parse(t.Rows[0][3].ToString()),
                                        t.Rows[0][4].ToString());
                return e;
            }
            catch
            { 
                return e;
            }
        }
    }
}
