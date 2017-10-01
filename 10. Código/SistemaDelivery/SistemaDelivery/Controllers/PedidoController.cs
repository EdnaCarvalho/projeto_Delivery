using Model.Models;
using Model.Models.Exceptions;
using Negocio.Business;
using SistemaDelivery.Util;
using System;
using System.Web.Mvc;

namespace SistemaDelivery.Controllers
{
    public class PedidoController : Controller
    {
        private GerenciadorProduto gerenciadorProduto;
        private GerenciadorPessoa gerenciadorPessoa;
        private GerenciadorPedido gerenciadorPedido;

        public PedidoController()
        {
            gerenciadorProduto = new GerenciadorProduto();
            gerenciadorPessoa = new GerenciadorPessoa();
            gerenciadorPedido = new GerenciadorPedido();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.USUARIO)]
        public ActionResult Create(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    ViewBag.ListaProduto = new SelectList(gerenciadorProduto.ObterTodos(id), "Id", "Produtos");
                }
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter as informações para criação do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações para criação do objeto.", e);
            }

        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
