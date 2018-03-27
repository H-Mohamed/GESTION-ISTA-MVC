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
            #region home refresh exit btns
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
            #endregion
            //DB controls

            //Navcontrols

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
    }
}
