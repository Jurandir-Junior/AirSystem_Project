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
    public partial class frmListaUsuarios : Form
    {
        UsuarioRepository repository = new UsuarioRepository();
        Usuario usuario = new Usuario();
        public frmListaUsuarios()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmListaUsuarios_Load(object sender, EventArgs e)
        {
            carregaLista();
        }
        private void carregaLista()
        {
            UsuarioRepository repository = new UsuarioRepository();
            dgvListaUsuarios.DataSource = null;
            dgvListaUsuarios.DataSource = repository.buscarTodos();
            alterarContador();
        }

        private void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            dgvListaUsuarios.DataSource = null;

            dgvListaUsuarios.DataSource = repository.buscarTodos().FindAll(x =>
                x.Nome.ToUpper().Contains(txbFiltro.Text.ToUpper())
            );

            alterarContador();

        }

        private void alterarContador()
        {
            lblContador.Text = $"{dgvListaUsuarios.RowCount} itens de {repository.buscarTodos().Count}";
        }

        private void dgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = dgvListaUsuarios.Rows[e.RowIndex];

            string nome = linha.Cells[1].Value.ToString();
            string sobrenome = linha.Cells[2].Value.ToString();
            string endereco = linha.Cells[3].Value.ToString();
            string nascimento = linha.Cells[4].Value.ToString();
            string userName = linha.Cells[6].Value.ToString();
            string senha = linha.Cells[7].Value.ToString();

            int codigo = Convert.ToInt32(linha.Cells[0].Value.ToString());
            int numero = Convert.ToInt32(linha.Cells[5].Value.ToString());

            usuario.Codigo = codigo;
            usuario.Nome = nome;
            usuario.Sobrenome = sobrenome;
            usuario.Endereco = endereco;
            usuario.Nascimento = Convert.ToDateTime(nascimento);
            usuario.Numero = numero;
            usuario.Username = userName;
            usuario.Senha = senha;
            

            tbxNome.Text = usuario.Nome;
            tbxSobrenome.Text = usuario.Sobrenome;
            tbxEndereco.Text = usuario.Endereco;
            dtpNascimento.Value = usuario.Nascimento;
            tbxNumero.Text = usuario.Numero.ToString();
            tbxUsuario.Text = usuario.Username;
            tbxSenha.Text = usuario.Senha;
            tbxSenhaConfirm.Text = usuario.Senha;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            new frmCadastro(usuario).ShowDialog();

            carregaLista();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new frmCadastro().ShowDialog();

            carregaLista();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
             DialogResult dr = MessageBox.Show("Deseja excluir este usuário?", "Atenção"
                    , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    int codigo = Convert.ToInt32(usuario.Codigo.ToString());

                    repository.deletar(codigo);

                    carregaLista();
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

        private void btnDeletar_Click(object sender, EventArgs e)
        {
                fotoPictureBox.Image = null;
        }
    }
}

