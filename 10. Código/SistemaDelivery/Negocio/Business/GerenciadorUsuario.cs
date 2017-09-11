using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorUsuario
    {

        private RepositorioUsuario persistencia;

        public GerenciadorUsuario()
        {
            persistencia = new RepositorioUsuario();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            persistencia.Adicionar(usuario);
            return usuario;
        }

        public void Editar(Usuario usuario)
        {
            persistencia.Editar(usuario);
        }

        public void Remover(Usuario usuario)
        {
            persistencia.Remover(usuario);
        }

        public Usuario Obter(int? id)
        {
            return persistencia.Obter(e => e.Id == id);
        }
        //Serve apenas para o administrador
        public List<Usuario> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
        
    }
}
