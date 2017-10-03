using System.Collections.Generic;
using Model.Models;
using Persistencia.Persistence;
using Model.Models.Exceptions;

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
			try{
				persistencia.Adicionar(pedido);
				return pedido;
			}
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar adicionar o objeto.", e);
            }
        }

        public void Editar(Pedido pedido)
        {
			try{
				persistencia.Editar(pedido);
			}
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar editar o objeto.", e);
            }
        }

        public void Remover(Pedido pedido)
        {
			try{
            persistencia.Remover(pedido);
			}
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar remover o objeto.", e);
            }
        }

        public Pedido Obter(int id)
        {
			try{
				return persistencia.Obter(e => e.Id == id);
			}
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        public List<Pedido> ObterTodos()
        {
			try{
				return persistencia.ObterTodos();
			}
            catch (PersistenciaException e)
            {
                throw new NegocioException("Erro ao tentar obter os objetos.", e);
            }
        }
    }
}
