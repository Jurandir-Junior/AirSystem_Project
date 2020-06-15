using AirSystem_Project.Models;
using AirSystem_Project.Repositories;
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
        UsuarioRepository repository = new UsuarioRepository();
        Usuario u = new Usuario();
        public static int idioma;
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            cbIdioma.SelectedIndex = 0;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            idioma = cbIdioma.SelectedIndex;
            new frmCadastro().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimeLbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            idioma = cbIdioma.SelectedIndex;
            repository.buscarTodos();
            
            if (txtUsuario.Text.Trim().Length != 0 || txtSenha.Text.Trim().Length != 0)
            {
                Usuario usuario = repository.BuscarUsuario(txtUsuario.Text, txtSenha.Text);

                if (usuario != null && usuario.Username == txtUsuario.Text && usuario.Senha == txtSenha.Text)
                {
                    if (idioma == 1) {
                        MessageBox.Show("Welcome", "Success");
                        new frmPrincipal(usuario).ShowDialog();
                        this.Close();
                    } 
                    else if (idioma == 0)
                    {
                        MessageBox.Show("Bem Vindo", "Entrada");
                        new frmPrincipal(usuario).ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    if (idioma == 1)
                    {
                        SystemSounds.Beep.Play();
                        MessageBox.Show("Username or password incorrect", "User not found");
                    }
                    else
                    {
                        SystemSounds.Beep.Play();
                        MessageBox.Show("Usuario ou senha incorretos", "Usuario não encontrado");
                    }
                }
            }
            else
            {
                if (idioma == 1)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Fill in the fields correctly", "Error");
                }
                else
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Preencha os campos corretamente", "Erro");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIdioma_DropDownClosed(object sender, EventArgs e)
        {
            idioma = cbIdioma.SelectedIndex;
            if (idioma == 1)
            {
                lblUsuario.Text = "Username";
                lblSenha.Text = "Password";
                btnEnter.Text = "Enter";
                btnExit.Text = "Exit";
                btnNewUser.Text = "New User";
                Refresh();
            } else
            {
                lblUsuario.Text = "Usuario";
                lblSenha.Text = "Senha";
                btnEnter.Text = "Entrar";
                btnExit.Text = "Sair";
                btnNewUser.Text = "Novo Usuario";
                Refresh();
            }
        }
    }
}
