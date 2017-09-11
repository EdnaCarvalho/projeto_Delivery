using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace SistemaDelivery.Controllers
{
    public class AdministradorController : Controller
    {

        private GerenciadorUsuario gerenciador;


        public AdministradorController()
        {
            gerenciador = new GerenciadorUsuario();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Usuario administrador = gerenciador.Obter(id);
                if (administrador != null)
                    return View(administrador);
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Create(Usuario administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Adicionar(administrador);
                    return RedirectToAction("ListagemUsuarios");
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
                Usuario administrador = gerenciador.Obter(id);
                if (administrador != null)
                    return View(administrador);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Edit(int id, Usuario administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(administrador);
                    return RedirectToAction("Index");
                }   
            }
            catch
            {                
            }
            return RedirectToAction("Index");
        }


        public ActionResult EditarUsuario(int? id)
        {
            if (id.HasValue)
            {
                Usuario administrador = gerenciador.Obter(id);
                if (administrador != null)
                    return View(administrador);
            }
            return RedirectToAction("ListagemUsuarios");
        }

        [HttpPost]
        public ActionResult EditarUsuario(int id, Usuario administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(administrador);
                    return RedirectToAction("ListagemUsuarios");
                }
            }
            catch
            {
            }
            return RedirectToAction("ListagemUsuarios");
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Usuario administrador = gerenciador.Obter(id);
                if (administrador != null)
                    return View(administrador);
            }
            return RedirectToAction("ListagemUsuarios");
        }

        
        [HttpPost]
        public ActionResult Delete(int id, Usuario administrador)
        {
            try
            {
                gerenciador.Remover(administrador);
                return RedirectToAction("ListagemUsuarios");                
            }
            catch
            {
               
            }
            return RedirectToAction("ListagemUsuarios");
        }

        public ActionResult ListagemUsuarios()
        {
            List<Usuario> usuarios = gerenciador.ObterTodos();
            if (usuarios == null || usuarios.Count == 0)
                usuarios = null;
            return View(usuarios);
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

    }
}
