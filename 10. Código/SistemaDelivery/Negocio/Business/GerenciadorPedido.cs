using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorPedido
    {
        private RepositorioPedido persistencia;

        public GerenciadorPedido()
        {
            persistencia = new RepositorioPedido();
        }

        public Pedido Adicionar(Pedido pedido)
        {
            persistencia.Adicionar(pedido);
            return pedido;
        }

        public void Editar(Pedido pedido)
        {
            persistencia.Editar(pedido);
        }

        public void Remover(Pedido pedido)
        {
            persistencia.Remover(pedido);
        }

        public Pedido Obter(int id)
        {
            return persistencia.Obter(e => e.Id == id);
        }

        public List<Pedido> ObterTodos()
        {
            return persistencia.ObterTodos();
        }
    }
}
