using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_MODEL__APP
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        } 
        #region Procedures
            private void ShowF(Form F)
        {
            this.Hide();
            F.Show();
        }
            private void set_Behaviour()
        {
            Exit.Click += (object o, EventArgs e) =>
            {
                Application.Exit();
            };
            etud.Click += (object o, EventArgs e) =>
            {
                Views.EtudiantV f = new Views.EtudiantV();
                ShowF(f);
            };
            prof.Click += (object o, EventArgs e) =>
            {
                Views.ProfesseurV f = new Views.ProfesseurV();
                ShowF(f);
            };
            mod.Click += (object o, EventArgs e) =>
            {
                Views.ModuleV f = new Views.ModuleV();
                ShowF(f);
            };
            Note.Click += (object o, EventArgs e) =>
            {
                Views.NoteV f = new Views.NoteV();
                ShowF(f);
            };
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            set_Behaviour();
        }
        public static void home()
        {
            Home h = new Home(); 
            ActiveForm.Hide();
            h.Show(); 
        }
    }
}
