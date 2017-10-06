using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;

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
            try
            {
                pedido.Id = listaPedidos.Count + 1;
                listaPedidos.Add(pedido);
                return pedido;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar adicionar objeto.", e);
            }
        }

        public void Editar(Pedido pedido)
        {
			try{
				int posicao = listaPedidos.FindIndex(e => e.Id == pedido.Id);
				listaPedidos[posicao] = pedido;
			}
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar editar o objeto.", e);
            }
        }

        public void Remover(Pedido pedido)
        {
			try{
            int posicao = listaPedidos.FindIndex(e => e.Id == pedido.Id);
            listaPedidos.RemoveAt(posicao);
			}
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar remover objeto.", e);
            }
        }

        public Pedido Obter(Func<Pedido, bool> where)
        {
			try{
				return listaPedidos.Where(where).FirstOrDefault();
			}
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter objeto.", e);
            }
        }

        public List<Pedido> ObterTodos()
        {
			try{
				return listaPedidos;
			}
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter os objetos.", e);
            }
        }
    }
}
