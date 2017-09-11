using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

namespace Persistencia.Persistence
{
    public class RepositorioUsuario
    {
        private static List<Usuario> listaUsuario;

        static RepositorioUsuario()
        {
            listaUsuario = new List<Usuario>();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.Id = listaUsuario.Count + 1;
            listaUsuario.Add(usuario);
            return usuario;
        }

        public void Editar(Usuario usuario)
        {
            int posicao = listaUsuario.FindIndex(e => e.Id == usuario.Id);
            listaUsuario[posicao] = usuario;
        }

        public void Remover(Usuario usuario)
        {
            int posicao = listaUsuario.FindIndex(e => e.Id == usuario.Id);
            listaUsuario.RemoveAt(posicao);
        }

        public Usuario Obter(Func<Usuario, bool> where)
        {
            return listaUsuario.Where(where).FirstOrDefault();
        }

        public List<Usuario> ObterTodos()
        {
            return listaUsuario;

        }
    }
}
