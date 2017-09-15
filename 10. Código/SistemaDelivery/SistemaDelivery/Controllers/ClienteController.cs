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
                    SessionHelper.Set(SessionKeys.Pessoa, Cliente);
                    return RedirectToAction("Index");
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
                if (cliente != null)
                    return View(cliente);
            }
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult AlterarDados(int id, Usuario cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
