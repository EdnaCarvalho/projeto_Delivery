using System.Web.Mvc;
using Model.Models.Account;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using System.Web.Security;

namespace SistemaDelivery.Controllers
{
    public class HomeController : Controller
    {
        private GerenciadorPessoa gerenciador;

        public HomeController()
        {
            gerenciador = new GerenciadorPessoa();
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel dadosLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Obtendo o usuário.
                    dadosLogin.Senha = Criptografia.GerarHashSenha(dadosLogin.Login + dadosLogin.Senha);
                    Pessoa pessoa = gerenciador.ObterByLoginSenha(dadosLogin.Login, dadosLogin.Senha);

                    // Autenticando.
                    if (pessoa != null)
                    {
                        FormsAuthentication.SetAuthCookie(pessoa.Login, false);
                        SessionHelper.Set(SessionKeys.Pessoa, pessoa);
                        if (pessoa.GetType() == typeof(Empresa))
                            return RedirectToAction("Index", new { controller = "Empresa" });
                        else 
                            if (( pessoa.GetType()== typeof(Usuario) && ((Usuario)pessoa).IsAdmin))
                                return RedirectToAction("Index", new { controller = "Administrador" });
                            else
                                return RedirectToAction("Index", new { controller = "Cliente" });
                    }
                }
                ModelState.AddModelError("", "Usuário e/ou senha inválidos.");
            }
            catch
            {
                ModelState.AddModelError("", "A autenticação falhou. Forneça informações válidas e tente novamente.");
            }
            // Se ocorrer algum erro, reexibe o formulário.
            return View();
        }

<<<<<<< HEAD
        [Authenticated]
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            return RedirectToAction("Login", "Home");
        }

=======
>>>>>>> parent of 78e5ff4... Apenas abertura do projeto
    }
}
