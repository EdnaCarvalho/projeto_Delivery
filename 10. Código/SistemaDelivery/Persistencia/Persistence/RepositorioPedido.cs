using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

namespace Persistencia.Persistence
{
   public class RepositorioPedido
    {
        private static List<Pedido> listaPedidos;

        static RepositorioPedido()
        {
            listaPedidos = new List<Pedido>();
        }

        public Pedido Adicionar(Pedido pedido)
        {
            pedido.Id = listaPedidos.Count + 1;
            listaPedidos.Add(pedido);
            return pedido;
        }

        public void Editar(Pedido pedido)
        {
            int posicao = listaPedidos.FindIndex(e => e.Id == pedido.Id);
            listaPedidos[posicao] = pedido;
        }

        public void Remover(Pedido pedido)
        {
            int posicao = listaPedidos.FindIndex(e => e.Id == pedido.Id);
            listaPedidos.RemoveAt(posicao);
        }

        public Pedido Obter(Func<Pedido, bool> where)
        {
            return listaPedidos.Where(where).FirstOrDefault();
        }

        public List<Pedido> ObterTodos()
        {
            return listaPedidos;
        }
    }
}
