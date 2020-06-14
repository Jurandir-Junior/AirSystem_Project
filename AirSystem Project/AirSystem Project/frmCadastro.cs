﻿using AirSystem_Project.Models;
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
    public partial class frmCadastro : Form
    {
        private Usuario usuario = null;
        public frmCadastro()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmCadastro(Usuario usuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.usuario = usuario;
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                tbxNome.Text = usuario.Nome;
                tbxSobrenome.Text = usuario.Sobrenome;
                tbxEndereco.Text = usuario.Endereco;
                dtpNascimento.Value = usuario.Nascimento;
                tbxNumero.Text = usuario.Numero.ToString();
                tbxUsuario.Text = usuario.Username;
                tbxSenha.Text = usuario.Senha;
                tbxSenhaConfirm.Text = usuario.Senha;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de Imagens(*.jpg;*.png)|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fotoPictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Utils.temCamposVazio(this))
           

            {
                UsuarioRepository repository = new UsuarioRepository();
                if (this.usuario == null)
                {

                    Usuario usuario = new Usuario
                    {
                        Nome = tbxNome.Text,
                        Sobrenome = tbxSobrenome.Text,
                        Endereco = tbxEndereco.Text,
                        Nascimento = dtpNascimento.Value,
                        Numero = Convert.ToInt32(tbxNumero.Text),
                        Username = tbxUsuario.Text,
                        Senha = tbxSenha.Text
                        
                    };
                   
                    repository.adicionar(usuario);

                    MessageBox.Show("Dados Salvos.",
                                    "Aviso", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);

                }
                else
                {


                    this.usuario.Nome = tbxNome.Text;
                    this.usuario.Sobrenome = tbxSobrenome.Text;
                    this.usuario.Endereco = tbxEndereco.Text;
                    this.usuario.Nascimento = dtpNascimento.Value;
                    this.usuario.Numero = Convert.ToInt32(tbxNumero.Text);
                    this.usuario.Username = tbxUsuario.Text;
                    this.usuario.Senha = tbxSenha.Text;
                    this.usuario.Admin = cbAdmin.Checked;

                    repository.editar(usuario);
                }
                this.Close();

            }
            else
            {   //Texto , Título, Botões, Ícone
                MessageBox.Show("Todos os campos são obrigatórios.",
                                "Aviso", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}
