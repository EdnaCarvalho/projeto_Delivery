﻿using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;

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
                    if(cliente != null)
                    {
                        cliente.IsAdmin = false;
                        gerenciador.Adicionar(cliente);
                        SessionHelper.Set(SessionKeys.Pessoa, cliente);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {

            }
            return View();
        }
        
        public ActionResult AlterarDados(int? id)
        {
            if (id.HasValue)
            {
                Usuario cliente = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (cliente != null )
                    return View(cliente);
            }
            return RedirectToAction("Index");
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
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

    }
}
