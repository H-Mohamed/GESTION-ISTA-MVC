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
    public partial class NoteV : Form
    {
        BindingSource bs = new BindingSource();
        public NoteV()
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
            {
                NoteV_Load(o, e); 
            };
            Exit.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            //DB controls 
            Add.Click += (object o, EventArgs e) =>
            {
                try
                {
                    Controlers.CNOTE.Ajouter(cE.Text, cM.Text,note.Text,DGV);
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
                    Controlers.CNOTE.Supprimer(cE.Text,cM.Text, DGV);
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
                    Controlers.CNOTE.Modifier(cE.Text, cM.Text, note.Text, DGV);
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
                    Resultat_Search(cE.Text, cM.Text);
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
            Controlers.DB.load_DGV(DGV,Controlers.CNOTE.ALL());
        }

        private void NoteV_Load(object sender, EventArgs e)
        {
            bs.DataSource = Controlers.CNOTE.ALL();
            set_behaviour(); data_loading();
        }
        private void Resultat_Search(string CE,string CM)
        {
            cE.Text = Controlers.CNOTE.Rechercher(CE, CM).codeEtudiant.ToString();
            cM.Text = Controlers.CNOTE.Rechercher(CE, CM).codeModule.ToString();
            note.Text = Controlers.CNOTE.Rechercher(CE, CM).note.ToString(); 
        }
    }
}
