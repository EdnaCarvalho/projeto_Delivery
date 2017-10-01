using System.Web.Mvc;
using Model.Models.Account;
using Model.Models.Exceptions;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using System.Web.Security;
using System;

namespace SistemaDelivery.Controllers
{
    public class HomeController : Controller
    {
        private GerenciadorPessoa gerenciador;

        public HomeController()
        {
            gerenciador = new GerenciadorPessoa();

            //TODO Retirar após os testes
            if (gerenciador.ObterByLogin("admin") == null)
            {
                Endereco endereco = new Endereco { Bairro = "hhhhhhhhhhhhhhhh", Cidade = "hhjjjjjjjjjjjjjj", Estado = "se", Numero = "77", RuaAv = "jjjjjjjjjjjjjjjjjjjj" };
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
            }
        }

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar acessar ação.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar acessar ação", e);
            }
        }

        public ActionResult AlterarSenha()
        {

            try
            {
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar acessar ação.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar acessar ação", e);
            }
        }

        public ActionResult Login()
        {

            try
            {
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar acessar ação.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar acessar ação", e);
            }
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

                    Pessoa usuario = gerenciador.ObterByLoginSenhaUsuario(dadosLogin.Login, dadosLogin.Senha);
                    // Autenticando.
                    if (usuario != null)
                    {
                        FormsAuthentication.SetAuthCookie(usuario.Login, false);
                        SessionHelper.Set(SessionKeys.Pessoa, (Usuario)usuario);
                        if ((usuario.GetType() == typeof(Usuario) && ((Usuario)usuario).IsAdmin))
                            return RedirectToAction("Index", new { controller = "Administrador" });
                        else
                            return RedirectToAction("Index", new { controller = "Cliente" });
                    }
                    else
                    {
                        Pessoa empresa = gerenciador.ObterByLoginSenhaEmpresa(dadosLogin.Login, dadosLogin.Senha);
                        if (empresa != null)
                        {
                            FormsAuthentication.SetAuthCookie(empresa.Login, false);
                            SessionHelper.Set(SessionKeys.Pessoa, (Empresa)empresa);
                            return RedirectToAction("Index", new { controller = "Empresa" });
                        }
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
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
                return RedirectToAction("Login", "Home");
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar acessar ação.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar acessar ação", e);
            }
        }      
           
    }
}
