using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using Model.Models.Exceptions;
using System;
using System.Web.Security;

namespace SistemaDelivery.Controllers
{
    public class ClienteController : Controller
    {
        private GerenciadorPessoa gerenciador;

        public ClienteController()
        {
            gerenciador = new GerenciadorPessoa();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE, MetodoAcao = "Index", Controladora = "Cliente")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                    Usuario cliente = new Usuario();
                    TryUpdateModel<Usuario>(cliente, collection.ToValueProvider());
                    gerenciador.Adicionar(cliente);
                    FormsAuthentication.SetAuthCookie(cliente.Login, false);
                    SessionHelper.Set(SessionKeys.Pessoa, cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro na criação do objeto.", e);
            }
        }


        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE, MetodoAcao = "Index", Controladora = "Cliente")]
        public ActionResult AlterarDados()
        {
            try
            {
                Usuario cliente = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (cliente != null)
                    return View(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }


        [HttpPost]
        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE, MetodoAcao = "Index", Controladora ="Cliente")]
        public ActionResult AlterarDados(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                    Usuario cliente = new Usuario();
                    TryUpdateModel<Usuario>(cliente, collection.ToValueProvider());
                    SessionHelper.Set(SessionKeys.Pessoa, cliente);
                    gerenciador.Editar(cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE, MetodoAcao = "Index", Controladora = "Cliente")]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE, MetodoAcao = "Index", Controladora = "Cliente")]
        public ActionResult AlterarSenha(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa cliente = SessionHelper.Get(SessionKeys.Pessoa) as Pessoa;
                    String senha = Criptografia.GerarHashSenha(cliente.Login + collection["SenhaAtual"]);

                    if (senha.ToLowerInvariant().Equals(cliente.Senha.ToLowerInvariant()))
                    {
                        cliente.Senha = Criptografia.GerarHashSenha(cliente.Login + collection["NovaSenha"]);
                        SessionHelper.Set(SessionKeys.Pessoa, cliente);
                        gerenciador.Editar(cliente);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Senha incorreta.");
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

    }
}
