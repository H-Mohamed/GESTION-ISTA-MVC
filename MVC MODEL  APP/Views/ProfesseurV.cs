using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_MODEL__APP.Views
{
    public partial class ProfesseurV : Form
    {
        BindingSource bs = new BindingSource();
        public ProfesseurV()
        {
            InitializeComponent();
            set_behaviour();
            data_loading();
        }
        public void set_behaviour()
        {
            //home refresh exit btns
            Home.Click += (object o,EventArgs e) =>
            {
                MVC_MODEL__APP.Home.home();
            };
            Refresh.Click += (object o, EventArgs e) =>
            {
                try
                {
                    ProfesseurV_Load(o, e);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            Exit.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            //DB controls
            Add.Click += (object o, EventArgs e) =>
            {try { 
                Controlers.CPROF.Ajouter(Codep.Text,Nomp.Text,Pnomp.Text,dipp.Text,emailp.Text,DGV);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            Del.Click += (object o, EventArgs e) =>
            {
                try
                {
                    Controlers.CPROF.Supprimer(Codep.Text, DGV);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            upd.Click += (object o, EventArgs e) =>
            {
            try { 
                Controlers.CPROF.Modifier(Codep.Text, Nomp.Text, Pnomp.Text, dipp.Text, emailp.Text, DGV);
            }
                catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

            };
            srch.Click += (object o, EventArgs e) =>
            { 
                try
                {
                    Resultat_Search(Codep.Text);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            //Navcontrols
            Precedent.Click += (object o, EventArgs e) =>
            {
                bs.MovePrevious();
            };
            Suivant.Click += (object o, EventArgs e) =>
            {
                bs.MoveNext();
            };
            dernier.Click += (object o, EventArgs e) =>
            {
                bs.MoveLast();
            };
            premier.Click += (object o, EventArgs e) =>
            {
                bs.MoveFirst();
            };
        }
        public void data_loading()
        {
            Controlers.DB.load_DGV(DGV, Controlers.CPROF.ALL());
        }
        private void ProfesseurV_Load(object sender, EventArgs e)
        {
            bs.DataSource = Controlers.CPROF.ALL();
        }
        private void Resultat_Search(string code)
        {
            Codep.Text = Controlers.CPROF.Rechercher(code).codeP.ToString();
            Nomp.Text = Controlers.CPROF.Rechercher(code).nom.ToString();
            Pnomp.Text = Controlers.CPROF.Rechercher(code).prenom.ToString();
            dipp.Text = Controlers.CPROF.Rechercher(code).diplome.ToString();
            emailp.Text = Controlers.CPROF.Rechercher(code).contact.ToString();
        }
    }
}
