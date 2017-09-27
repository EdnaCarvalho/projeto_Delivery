using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using Model.Models.Exceptions;
using System;

namespace SistemaDelivery.Controllers
{
    public class ProdutoController : Controller
    {
        private GerenciadorProduto gerenciador;
        public Empresa empresa;

        public ProdutoController()
        {
            
        }

        public ActionResult Index()
        {
            empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
            List<Produto> produtos = gerenciador.ObterTodos(empresa.Id);
            if (produtos == null || produtos.Count == 0)
                produtos = null;
            return View(produtos);
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Produto produto = gerenciador.Obter(id);
                    if (produto != null)
                        return View(produto);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
            
        }

        public ActionResult Create()
        {
            try
            {
                ViewBag.ListaDescricao = new SelectList(gerenciador.ObterTodosTipos(), "Id", "Descricao");
                ViewBag.ListaMarca = new SelectList(gerenciador.ObterTodosTipos(), "Id", "Marca");
                return View();
            }
            catch(Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
            
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TipoProduto TipoProduto = new TipoProduto();
                    Produto produto = new Produto() { Empresa = empresa, TipoProduto = TipoProduto };
                    TryUpdateModel(produto, form.ToValueProvider());
                    produto.TipoProduto = gerenciador.ObterTipoProduto(produto.TipoProduto.Id);
                    gerenciador.Adicionar(produto);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar criar o objeto.", e);
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Produto produto = gerenciador.Obter(id);
                    if (produto != null)
                        return View(produto);
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
            
        }

        [HttpPost]
        public ActionResult Edit(int id, Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(produto);
                    return RedirectToAction("Index");
                }

            }
            catch(Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Produto produto = gerenciador.Obter(id);
                    if (produto != null)
                        return View(produto);
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Remover(new Produto { Id= id});
                    return RedirectToAction("Index");
                }

            }
            catch(Exception e)
            {
                throw new ControllerException("Erro ao tentar remover o objeto.", e);
            }
            return View();
        }
    }
}
