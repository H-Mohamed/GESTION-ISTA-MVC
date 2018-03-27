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
                ProfesseurV_Load(o, e);
            };
            Exit.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            //DB controls
            Add.Click += (object o, EventArgs e) =>
            {
                Controlers.CPROF.Ajouter(Codep.Text,Nomp.Text,Pnomp.Text,dipp.Text,emailp.Text,DGV);
            };
            Del.Click += (object o, EventArgs e) =>
            {
                Controlers.CPROF.Supprimer(Codep.Text, DGV);
            };
            upd.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            srch.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            //Navcontrols
            Precedent.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            Suivant.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            dernier.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            premier.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
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
         
    }
}
