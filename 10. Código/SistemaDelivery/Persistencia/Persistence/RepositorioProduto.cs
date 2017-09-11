using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

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
            produto.Id = listaProdutos.Count + 1;
            listaProdutos.Add(produto);
            return produto;
        }

        public void Editar(Produto produto)
        {
            int posicao = listaProdutos.FindIndex(e => e.Id == produto.Id);
            listaProdutos[posicao] = produto;
        }

        public void Remover(Produto produto)
        {
            int posicao = listaProdutos.FindIndex(e => e.Id == produto.Id);
            listaProdutos.RemoveAt(posicao);
        }

        public Produto Obter(Func<Produto, bool> where)
        {
            return listaProdutos.Where(where).FirstOrDefault();
        }

        public List<Produto> ObterTodos(int codigoEmpresa)
        {
            return listaProdutos.Where(p => p.Empresa.Id == codigoEmpresa).ToList();
        }

        public List<TipoProduto> ObterTodosTipos()
        {
            return listaTipoProduto;
        }

        public TipoProduto ObterTipo(Func<TipoProduto, bool> where)
        {
            return listaTipoProduto.Where(where).FirstOrDefault();
        }
    }
}