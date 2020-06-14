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
        public frmPrincipal()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmListaUsuarios().ShowDialog();
        }
    }
}
