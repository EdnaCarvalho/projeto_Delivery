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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE)]
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

        public ActionResult Cadastro()
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
        public ActionResult Cadastro(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa pessoa = gerenciador.ObterByLogin(collection["Login"]);
                    if (pessoa == null)
                    {
                        collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                        Usuario cliente = new Usuario();
                        TryUpdateModel<Pessoa>(cliente, collection.ToValueProvider());
                        cliente.ConfirmarSenha = cliente.Senha;
                        gerenciador.Adicionar(cliente);
                        FormsAuthentication.SetAuthCookie(cliente.Login, false);
                        SessionHelper.Set(SessionKeys.Pessoa, cliente);
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Login já existente.");
                }
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar criar o objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro na criação do objeto.", e);
            }
        }


        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE)]
        public ActionResult AlterarDados()
        {
            try
            {
                Usuario cliente = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (cliente != null)
                    return View(cliente);

                return RedirectToAction("Index");
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }


        [HttpPost]
        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE)]
        public ActionResult AlterarDados(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario cliente = new Usuario();
                    TryUpdateModel<Usuario>(cliente, collection.ToValueProvider());
                    SessionHelper.Set(SessionKeys.Pessoa, cliente);
                    gerenciador.Editar(cliente);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE)]
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

        [HttpPost]
        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.CLIENTE)]
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
                        cliente.ConfirmarSenha = cliente.Senha;
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

    }
}
