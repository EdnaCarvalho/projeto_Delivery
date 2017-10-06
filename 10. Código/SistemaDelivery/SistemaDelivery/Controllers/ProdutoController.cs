using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using Model.Models.Exceptions;
using System;

namespace SistemaDelivery.Controllers
{
    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
    public class ProdutoController : Controller
    {
        private GerenciadorProduto gerenciador;

        public ProdutoController()
        {
            gerenciador = new GerenciadorProduto();
        }

        public ActionResult Index()
        {
            try
            {
                Empresa empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
                List<Produto> produtos = gerenciador.ObterTodos(empresa.Id);
                if (produtos == null || produtos.Count == 0)
                    produtos = null;
                return View(produtos);
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", n);
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
        public ActionResult Create(FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Empresa empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
                    if (empresa != null)
                    {
                        Produto produto = new Produto() { TipoProduto = new TipoProduto(), Empresa = new Empresa() };
                        TryUpdateModel<Produto>(produto, form.ToValueProvider());
                        produto.Empresa = empresa;
                        produto.TipoProduto = gerenciador.ObterTipoProduto(produto.TipoProduto.Id);
                        gerenciador.Adicionar(produto);
                        return RedirectToAction("Index");
                    }
                }
                return View();
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }            
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto produto = new Produto() { Empresa = new Empresa(), TipoProduto = new TipoProduto() };
                    TryUpdateModel<Produto>(produto, form.ToValueProvider());
                    produto.Empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
                    produto.TipoProduto = gerenciador.ObterTipoProduto(produto.TipoProduto.Id);
                    gerenciador.Editar(produto);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", n);
            }
            catch (Exception e)
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
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar remover o objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar remover o objeto.", e);
            }
        }
    }
}
