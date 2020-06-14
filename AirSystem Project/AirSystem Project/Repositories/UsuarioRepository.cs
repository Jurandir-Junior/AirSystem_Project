using AirSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSystem_Project.Repositories
{
    class UsuarioRepository
    {
        private static List<Usuario> usuarios;

        private static int contador = 1;


        public UsuarioRepository()
        {
            if (usuarios == null)
            {
                usuarios = new List<Usuario>();

                usuarios.Add(new Usuario
                {
                    Codigo = 1,
                    Nome = "Junior",
                    Sobrenome = "Santos",
                    Endereco = "Rua Morais Madureira",
                    Nascimento = Convert.ToDateTime("26/01/1999"),
                    Numero = 288,
                    Username = "TwitchyTail",
                    Senha = "6j-NF7b!{S",
                    Admin = true
                });
                contador++;
                usuarios.Add(new Usuario
                {
                    Codigo = 2,
                    Nome = "Nathan",
                    Sobrenome = "Matos",
                    Endereco = "Rua Servidão Almeida",
                    Nascimento = Convert.ToDateTime("05/10/2000"),
                    Numero = 206,
                    Username = "Gearsy",
                    Senha = "Zenitpolar741256",
                    Admin = false
                });
                contador++;
            }
        }

        public List<Usuario> buscarTodos()
        {
            return usuarios;
        }

        public void adicionar(Usuario usuario)
        {
            usuario.Codigo = contador;

            usuarios.Add(usuario);
            contador++;
        }

        public void editar(Usuario usuario)
        {
            Usuario u = usuarios.Find(x => x.Codigo == usuario.Codigo);
            usuarios[usuarios.IndexOf(u)] = usuario;
        }

        public void deletar(int Codigo)
        {
            Usuario usuario = usuarios.Find(x => x.Codigo == Codigo);

            usuarios.Remove(usuario);

        }
    }
}
