using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

namespace Negocio.Business
{
    public class GerenciadorProduto
    {
        private RepositorioProduto persistencia;

        public GerenciadorProduto()
        {
            persistencia = new RepositorioProduto();
        }

        public Produto Adicionar(Produto produto)
        {
            try
            {
                persistencia.Adicionar(produto);
                return produto;
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar adicionar o objeto.", e);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                persistencia.Editar(produto);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar editar o objeto.", e);
            }
        }

        public void Remover(Produto produto)
        {
            try
            {
                persistencia.Remover(produto);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar remover o objeto.", e);
            }
        }

        public Produto Obter(int? id)
        {
            try
            {
                return persistencia.Obter(e => e.Id == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter o objeto.", e);
            }
        }

        public List<Produto> ObterTodos(int? codigoEmpresa)
        {
            try
            {
                return persistencia.ObterTodos(codigoEmpresa);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter os objetos.", e);
            }
        }

        public List<TipoProduto> ObterTodosTipos()
        {
            try
            {
                return persistencia.ObterTodosTipos();
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        public TipoProduto ObterTipoProduto(int? id)
        {
            try
            {
                return persistencia.ObterTipo(t => t.Id == id);
            }
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter as informações do objeto.", e);
            }
        }
    }
}
