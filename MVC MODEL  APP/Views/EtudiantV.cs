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
            {
                EtudiantV_Load(o, e);
            };
            Exit.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            //DB controls

            //Navcontrols

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
    }
}
