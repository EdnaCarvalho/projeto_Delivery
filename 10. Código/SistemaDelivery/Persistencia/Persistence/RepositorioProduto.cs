using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;

namespace Persistencia.Persistence
{
    public class RepositorioProduto
    {
        private static List<Produto> listaProdutos;

        private static List<TipoProduto> listaTipoProduto = new List<TipoProduto>()
        {
            new TipoProduto() { Id = 1, Tipo = "agua", Marca = "Lev", Descricao = "2l" },
            new TipoProduto() { Id = 2, Tipo = "agua", Marca = "Indaiá", Descricao = "2l" },
            new TipoProduto() { Id = 3, Tipo = "agua", Marca = "Cristal", Descricao = "2l" },
            new TipoProduto() { Id = 4, Tipo = "gas", Marca = "Ultragaz", Descricao = "P45" },
            new TipoProduto() { Id = 5, Tipo = "gas", Marca = "Liquigaz", Descricao = "P13" }
        };

        static RepositorioProduto()
        {
            listaProdutos = new List<Produto>();
        }

        public Produto Adicionar(Produto produto)
        {
            try
            {
                produto.Id = listaProdutos.Count + 1;
                listaProdutos.Add(produto);
                return produto;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar adicionar objeto.", e);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                int posicao = listaProdutos.FindIndex(e => e.Id == produto.Id);
                listaProdutos[posicao] = produto;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar editar o objeto.", e);
            }
        }

        public void Remover(Produto produto)
        {
            try
            {
                int posicao = listaProdutos.FindIndex(e => e.Id == produto.Id);
                listaProdutos.RemoveAt(posicao);
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar remover objeto.", e);
            }
        }

        public Produto Obter(Func<Produto, bool> where)
        {
            try
            {
                return listaProdutos.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter objeto.", e);
            }
        }

        public List<Produto> ObterTodos(int? codigoEmpresa)
        {
            try
            {
                return listaProdutos.Where(p => p.Empresa.Id == codigoEmpresa).ToList();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter os objetos.", e);
            }
        }

        public List<TipoProduto> ObterTodosTipos()
        {
            try
            {
                return listaTipoProduto;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter os objetos.", e);
            }
        }

        public TipoProduto ObterTipo(Func<TipoProduto, bool> where)
        {
            try
            {
                return listaTipoProduto.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter informação do o objeto.", e);
            }
        }
    }
}