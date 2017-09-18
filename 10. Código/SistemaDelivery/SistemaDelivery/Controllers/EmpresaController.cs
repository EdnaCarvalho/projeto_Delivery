using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;

namespace SistemaDelivery.Controllers
{
    public class EmpresaController : Controller
    {
        private GerenciadorPessoa gerenciador;

        public EmpresaController ()
        {
            gerenciador = new GerenciadorPessoa();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Empresa empresa = gerenciador.ObterEmpresa(id);
                if(empresa != null)
                    return View(empresa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Adicionar(empresa);
                    return RedirectToAction("ListagemDistribuidoras");
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
                Empresa empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
                if (empresa != null)
                    return View(empresa);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AlterarDados(int id, Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SessionHelper.Set(SessionKeys.Pessoa,empresa);
                    gerenciador.Editar(empresa);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
               
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Empresa empresa = gerenciador.ObterEmpresa(id);
                if (empresa != null)
                    return View(empresa);
            }
            return RedirectToAction("ListagemDistribuidoras");
        }

        [HttpPost]
        public ActionResult Edit(int id, Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(empresa);
                    return RedirectToAction("ListagemDistribuidoras");
                }
            }
            catch
            {

            }
            return View();
        }

        public ActionResult Delete(int? id)
        {

            if (id.HasValue)
            {
                Empresa empresa = gerenciador.ObterEmpresa(id);
                if (empresa != null)
                    return View(empresa);
            }
            return RedirectToAction("ListagemDistribuidoras");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Remover(new Empresa { Id = id });
                    return RedirectToAction("ListagemDistribuidoras");
                }
            }
            catch
            {
                
            }
            return View();
        }
        public ActionResult ListagemDistribuidoras()
        {
            
            List<Empresa> empresa = gerenciador.ObterEmpresas();
            if (empresa == null || empresa.Count == 0)
                empresa = null;
            return View(empresa);
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

    }
}
