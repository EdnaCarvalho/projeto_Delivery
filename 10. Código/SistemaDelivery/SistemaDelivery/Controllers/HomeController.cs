using System.Web.Mvc;
using Model.Models;

namespace SistemaDelivery.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }  
        
        public ActionResult AlterarSenha()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
