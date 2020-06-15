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

        public Usuario BuscarUsuario(string user, string senha)
        {
            if (user != null && senha != null)
            {
            Usuario usuario = usuarios.Find(x => x.Username == user && x.Senha == senha);
            return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
