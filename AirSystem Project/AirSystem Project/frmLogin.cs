using AirSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            new frmCadastro().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimeLbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim().Length == 0 || txtSenha.Text.Trim().Length == 0)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Preencha os campos corretamente.", "Erro");
            }
            else
            {
                MessageBox.Show("Bem Vindo", "Entrada");
                new frmPrincipal().ShowDialog();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
