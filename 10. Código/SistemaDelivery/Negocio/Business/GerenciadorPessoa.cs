using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;
using System;

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
            catch (Exception e)
            {
                throw new NegocioException("Erro ao tentar adicionar objeto.", e);
            }
        }

        public void Editar(Pessoa pessoa)
        {
            try
            {
                persistencia.Editar(pessoa);
            }
            catch (Exception e)
            {
                throw new NegocioException("Erro ao tentar editar objeto.", e);
            }
        }

        public void Remover(Pessoa pessoa)
        {
            try
            {
                persistencia.Remover(pessoa);
            }
            catch (Exception e)
            {
                throw new NegocioException("Erro ao tentar remover objeto.", e);
            }
        }

        public Pessoa ObterByLoginSenha(string login, string senha)
        {
            try
            {
                Pessoa pessoa = persistencia.ObterUsuario(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                    e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
                if (pessoa == null)
                    pessoa = persistencia.ObterEmpresa(e => e.Login.ToLowerInvariant().Equals(login.ToLowerInvariant()) &&
                        e.Senha.ToLowerInvariant().Equals(senha.ToLowerInvariant()));
                return pessoa;
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                throw new NegocioException("Erro ao tentar obter os objetos.", e);
            }
        }
    }
}
