﻿using Model.Models;
using Model.Models.Exceptions;
using Negocio.Business;
using SistemaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult ListagemPedidos()
        {
            try
            {
                Pessoa pessoa = SessionHelper.Get(SessionKeys.Pessoa) as Pessoa;
                if(pessoa != null)
                {
                    List<Pedido> pedidos;
                    if (pessoa.GetType() == typeof(Usuario))
                    {
                        pedidos = gerenciadorPedido.ObterTodos().Where(p => p.Cliente.Id == pessoa.Id).ToList();
                    }
                    else
                    {
                       pedidos = gerenciadorPedido.ObterTodos().Where(p => p.Empresa.Id == pessoa.Id).ToList();
                    }
                    if (pedidos == null || pedidos.Count == 0)
                        pedidos = null;
                    return View(pedidos);
                }
                    return RedirectToAction("Index");

            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", e);
            }
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.USUARIO)]
        public ActionResult RealizarPedido(int? id)
        {
            try
            {
                Usuario cliente = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (cliente != null)
                {
                    List<Produto> produtos = gerenciadorProduto.ObterTodos(id);
                    if (produtos == null || produtos.Count == 0)
                    {
                        produtos = null;
                    }

                    ViewBag.Empresa = gerenciadorPessoa.ObterEmpresa(id);
                    ViewBag.ListaProduto = produtos;
                    ViewBag.Endereco = cliente.Endereco;
                    return View();
                }
                else
                    return RedirectToAction("Index");
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

        [HttpPost]
        public ActionResult RealizarPedido(Empresa empresa, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pedido pedido = new Pedido();
                    TryUpdateModel<Pedido>(pedido, collection.ToValueProvider());
                    pedido.Status = "ESPERA";
                    gerenciadorPedido.Adicionar(pedido);
                    return RedirectToAction("ListagemDistribuidoras", "Empresa");
                }
                return RedirectToAction("ListagemDistribuidoras", "Empresa");
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar criar o objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar criar o objeto.", e);
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
