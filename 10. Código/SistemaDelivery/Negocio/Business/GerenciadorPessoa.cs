using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorPessoa
    {
        private RepositorioPessoa persistencia;

        public GerenciadorPessoa()
        {
            persistencia = new RepositorioPessoa();
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            persistencia.Adicionar(pessoa);
            return pessoa;
        }

        public void Editar(Pessoa pessoa)
        {
            persistencia.Editar(pessoa);
        }

        public void Remover(Pessoa pessoa)
        {
            persistencia.Remover(pessoa);
        }

        public Pessoa ObterByLoginSenha(string login, string senha)
        {
            Pessoa pessoa = persistencia.ObterUsuario(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
            if (pessoa == null)
            {
                pessoa = persistencia.ObterEmpresa(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                    e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
            }
            return pessoa;
        }

        public Empresa ObterEmpresa(int? id)
        {
            return persistencia.ObterEmpresa(e => e.Id == id);
        }

        public Usuario ObterUsuario(int? id)
        {
            return persistencia.ObterUsuario(e => e.Id == id);
        }

        public List<Empresa> ObterEmpresas()
        {
            return persistencia.ObterEmpresas();
        }

        public List<Usuario> ObterUsuarios()
        {
            return persistencia.ObterUsuarios();
        }
    }
}
