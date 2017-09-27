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

            //TODO Retirar após os testes
            Endereco endereco = new Endereco { Bairro = "hhhhhhhhhhhhhhhh", Cidade = "hhjjjjjjjjjjjjjj", Estado = "se", Numero = "77", RuaAv = "jjjjjjjjjjjjjjjjjjjj" };

            Empresa empresa = new Empresa
            {
                Nome = "Distribuidora Bene",
                Email = "amanda@nn.com",
                Cnpj = "hhhhhhhhhh",
                Cpf = "jjjjjjjjjj",
                Proprietario = "manoel",
                Status = "Aberto",
                Telefone = "99999999",
                Senha = "empresa",
                ConfirmarSenha = "12345",
                Endereco = endereco,
                Login = "empresa",
                Produtos = null,
                Pedidos = null
            };

            empresa.Senha = Criptografia.GerarHashSenha(empresa.Login + empresa.Senha);

            Usuario administrador = new Usuario
            {
                Nome = "Maria Bene",
                Email = "edna@nn.com",
                IsAdmin = true,
                Telefone = "99999999",
                Senha = "admin",
                ConfirmarSenha = "12345",
                Endereco = endereco,
                Login = "admin",
                Pedidos = null
            };
            administrador.Senha = Criptografia.GerarHashSenha(administrador.Login + administrador.Senha);
            gerenciador.Adicionar(administrador);
            gerenciador.Adicionar(empresa);
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
                            if ((pessoa.GetType() == typeof(Usuario) && ((Usuario)pessoa).IsAdmin))
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
    }
}
