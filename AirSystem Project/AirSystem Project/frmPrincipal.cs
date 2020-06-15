using AirSystem_Project.Models;
using AirSystem_Project.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem_Project
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(Usuario usuario)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            if (usuario.Admin == true)
            {
                button5.Visible = true;
            }
            else
            {
                button5.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmListaUsuarios().ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if(frmLogin.idioma == 1)
            {
                Text = "Main - AirSystem";
                button1.Text = "List Planes";
                button2.Text = "Manage Plane";
                button3.Text = "Manage Company";
                button4.Text = "Manage Reports";
                button5.Text = "List Users";

            }
        }
    }
}
