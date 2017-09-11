using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;

namespace SistemaDelivery.Controllers
{
    public class ClienteController : Controller
    {

        private GerenciadorUsuario gerenciador;

        public ClienteController()
        {
            gerenciador = new GerenciadorUsuario();
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
        public ActionResult Create(Usuario Cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente.IsAdmin = false;
                    gerenciador.Adicionar(Cliente);
                    SessionHelper.Set(SessionKeys.Usuario, Cliente);
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
                Usuario cliente = gerenciador.Obter(id);
                if (cliente != null)
                    return View(cliente);
            }
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult Edit(int id, Usuario cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(cliente);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

    }
}
