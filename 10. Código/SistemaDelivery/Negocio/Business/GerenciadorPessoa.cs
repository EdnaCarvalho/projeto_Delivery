using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

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
            try
            {
                persistencia.Adicionar(pessoa);
                return pessoa;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar adicionar o objeto.", e);
            }
        }

        public void Editar(Pessoa pessoa)
        {
            try
            {
                persistencia.Editar(pessoa);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar editar o objeto.", e);
            }
        }

        public void Remover(Pessoa pessoa)
        {
            try
            {
                persistencia.Remover(pessoa);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar remover o objeto.", e);
            }
        }

        public Usuario ObterByLoginSenhaUsuario(string login, string senha)
        {
            try
            {
                Usuario pessoa = persistencia.ObterUsuario(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                    e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
                return pessoa;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        public Empresa ObterByLoginSenhaEmpresa(string login, string senha)
        {
            try
            {
                Empresa pessoa = persistencia.ObterEmpresa(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                    e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
                return pessoa;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        public Pessoa ObterByLogin(string login)
        {
            try
            {
                Pessoa pessoa = persistencia.ObterUsuario(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()));
                if (pessoa == null)
                    pessoa = persistencia.ObterEmpresa(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()));
                return pessoa;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        public Empresa ObterEmpresa(int? id)
        {
            try
            {
                return persistencia.ObterEmpresa(e => e.Id == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter objeto.", e);
            }
        }

        public Usuario ObterUsuario(int? id)
        {
            try
            {
                return persistencia.ObterUsuario(e => e.Id == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter objeto.", e);
            }
        }

        public List<Empresa> ObterEmpresas()
        {
            try
            {
                return persistencia.ObterEmpresas();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter os objetos.", e);
            }
        }

        public List<Usuario> ObterUsuarios()
        {
            try
            {
                return persistencia.ObterUsuarios();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter os objetos.", e);
            }
        }
    }
}
