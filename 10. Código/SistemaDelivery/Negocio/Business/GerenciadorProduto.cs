using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;

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
            persistencia.Adicionar(produto);
            return produto;
        }

        public void Editar(Produto produto)
        {
            persistencia.Editar(produto);
        }

        public void Remover(Produto produto)
        {
            persistencia.Remover(produto);
        }

        public Produto Obter(int? id)
        {
            return persistencia.Obter(e => e.Id == id);
        }

        public List<Produto> ObterTodos(int codigoEmpresa)
        {
            return persistencia.ObterTodos(codigoEmpresa);
        }

        public List<TipoProduto> ObterTodosTipos()
        {
            return persistencia.ObterTodosTipos();
        }

        public TipoProduto ObterTipoProduto(int? id)
        {
            return persistencia.ObterTipo(t => t.Id == id);
        }
    }
}
