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
    public partial class ModuleV : Form
    {
        BindingSource bs= new BindingSource();
        public ModuleV()
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
            { try { 
                ModuleV_Load(o, e); }
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
            {try
                {
                    Controlers.CMOD.Ajouter(Code.Text, intitulé.Text, int.Parse(Code.Text), prevu.Value, realise.Value, DGV);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            Del.Click += (object o, EventArgs e) =>
            {try { 
                Controlers.CMOD.Supprimer(Code.Text, DGV);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            };
            upd.Click += (object o, EventArgs e) =>
            {try { 
                Controlers.CMOD.Modifier(Code.Text, intitulé.Text, int.Parse(Codep.Text), prevu.Value, realise.Value, DGV);
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
                catch(Exception E)
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
            Controlers.DB.load_DGV(DGV, Controlers.CMOD.ALL());
        }

        private void ModuleV_Load(object sender, EventArgs e)
        {
            set_behaviour(); data_loading();
            bs.DataSource = Controlers.CMOD.ALL();
        }
        private void Resultat_Search(string codem)
        {
            Code.Text = Controlers.CMOD.Rechercher(codem).codeM.ToString();
            Codep.Text = Controlers.CMOD.Rechercher(codem).codeP.ToString();
            intitulé.Text = Controlers.CMOD.Rechercher(codem).nomM.ToString();
            prevu.Text = Controlers.CMOD.Rechercher(codem).dateP.ToString();
            realise.Text = Controlers.CMOD.Rechercher(codem).DateR.ToString();
        }
    }
}
