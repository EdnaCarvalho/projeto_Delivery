using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using System.Web.Security;

namespace SistemaDelivery.Controllers
{
    public class AdministradorController : Controller
    {

        private GerenciadorPessoa gerenciador;


        public AdministradorController()
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
                Usuario administrador = gerenciador.ObterUsuario(id);
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
        
        public ActionResult AlterarDados(int? id)
        {
            if (id.HasValue)
            {
                Usuario administrador = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (administrador != null)
                    return View(administrador);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AlterarDados(int id, Usuario administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SessionHelper.Set(SessionKeys.Pessoa,administrador);
                    gerenciador.Editar(administrador);
                    return RedirectToAction("Index");
                }   
            }
            catch
            {                
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Usuario usuario = gerenciador.ObterUsuario(id);
                if (usuario != null)
                    return View(usuario);
            }
            return RedirectToAction("ListagemUsuarios");
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(usuario);
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
                Usuario usuario = gerenciador.ObterUsuario(id);
                if (usuario != null)
                    return View(usuario);
            }
            return RedirectToAction("ListagemUsuarios");
        }

        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Remover(new Usuario { Id = id });
                    return RedirectToAction("ListagemUsuarios");
                }
            }
            catch
            {
               
            }
            return RedirectToAction("ListagemUsuarios");
        }

        public ActionResult ListagemUsuarios()
        {
            List<Usuario> usuarios = gerenciador.ObterUsuarios().Where(u => u.Id != ((Usuario)SessionHelper.Get(SessionKeys.Pessoa)).Id).ToList();
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
