using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using Model.Models.Exceptions;
using System;

namespace SistemaDelivery.Controllers
{
    public class ClienteController : Controller
    {

        private GerenciadorPessoa gerenciador;

        public ClienteController()
        {
            gerenciador = new GerenciadorPessoa();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                    Usuario cliente = new Usuario();
                    TryUpdateModel<Usuario>(cliente, collection.ToValueProvider());
                    cliente.IsAdmin = false;
                    gerenciador.Adicionar(cliente);
                    SessionHelper.Set(SessionKeys.Pessoa, cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro na criação do objeto.", e);
            }
        }

        public ActionResult AlterarDados(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Usuario cliente = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                    if (cliente != null)
                        return View(cliente);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }


        [HttpPost]
        public ActionResult AlterarDados(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                    Usuario cliente = new Usuario();
                    TryUpdateModel<Usuario>(cliente, collection.ToValueProvider());
                    SessionHelper.Set(SessionKeys.Pessoa, cliente);
                    gerenciador.Editar(cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

    }
}
