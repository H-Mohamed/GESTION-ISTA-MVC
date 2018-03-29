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
    public partial class EtudiantV : Form
    {
        BindingSource bs = new BindingSource();
        public EtudiantV()
        {
            InitializeComponent();
        }
        public void set_behaviour()
        {
            //home refresh exit btns
            Home.Click += (object o, EventArgs e) =>
            {
                MVC_MODEL__APP.Home.home();
            };
            Refresh.Click += (object o, EventArgs e) =>
            {try { 
                EtudiantV_Load(o, e);
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
            {
                try{
                    Controlers.CETU.Ajouter(Code.Text, Nom.Text, Prenom.Text, DNEt.Value.ToShortDateString(), Email.Text, DGV);
                }
                    catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            Del.Click += (object o, EventArgs e) =>
            {
                try {
                    Controlers.CETU.Supprimer(Code.Text, DGV);
                }
                catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    } 
            };
            upd.Click += (object o, EventArgs e) =>
            {
                try
                {
                    Controlers.CETU.Ajouter(Code.Text, Nom.Text, Prenom.Text, DNEt.Value.ToShortDateString(), Email.Text, DGV);
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
                    Resultat_Search(Code.Text);
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
            Controlers.DB.load_DGV(DGV, Controlers.CETU.ALL());
        }
        private void EtudiantV_Load(object sender, EventArgs e)
        {
            set_behaviour(); data_loading();
            bs.DataSource = Controlers.CETU.ALL();
        }
        private void Resultat_Search(string codem)
        {
            Code.Text = Controlers.CETU.Rechercher(codem).codeE.ToString();
            Nom.Text = Controlers.CETU.Rechercher(codem).nom.ToString();
            Prenom.Text = Controlers.CETU.Rechercher(codem).prenom.ToString();
            DNEt.Text = Controlers.CETU.Rechercher(codem).daten.ToString();
            Email.Text = Controlers.CETU.Rechercher(codem).email.ToString();
        }
    }
}
