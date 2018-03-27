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
            {
                ModuleV_Load(o, e);
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
            Controlers.DB.load_DGV(DGV, Controlers.CMOD.ALL());
        }

        private void ModuleV_Load(object sender, EventArgs e)
        {
            set_behaviour(); data_loading();
            bs.DataSource = Controlers.CMOD.ALL();
        }
    }
}
