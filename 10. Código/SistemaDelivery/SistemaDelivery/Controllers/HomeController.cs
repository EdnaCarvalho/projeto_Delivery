using System.Web.Mvc;

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
      
    }
}
