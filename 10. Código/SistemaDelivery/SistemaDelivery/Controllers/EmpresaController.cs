using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using System;
using Model.Models.Exceptions;

namespace SistemaDelivery.Controllers
{

    public class EmpresaController : Controller
    {
        private GerenciadorPessoa gerenciador;

        public EmpresaController()
        {
            gerenciador = new GerenciadorPessoa();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
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

        [Authenticated]
        [CustomAuthorize (NivelAcesso = Util.TipoUsuario.USUARIO)]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Empresa empresa = gerenciador.ObterEmpresa(id);
                    if (empresa != null)
                        return View(empresa);
                }
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

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
        public ActionResult Create()
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa pessoa = gerenciador.ObterByLogin(collection["Login"]);
                    if (pessoa == null)
                    {
                        collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                        Empresa empresa = new Empresa();
                        TryUpdateModel<Empresa>(empresa, collection.ToValueProvider());
                        empresa.ConfirmarSenha = empresa.Senha;
                        gerenciador.Adicionar(empresa);
                        return RedirectToAction("ListagemDistribuidoras");
                    }
                    ModelState.AddModelError("", "Login já existente.");
                }
                return View(collection);
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar criar o objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar criar o objeto.", e);
            }
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
        public ActionResult AlterarDados()
        {
            try
            {
                Empresa empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
                if (empresa != null)
                    return View(empresa);
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
        public ActionResult AlterarDados(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Empresa empresa = new Empresa();
                    TryUpdateModel<Empresa>(empresa, collection.ToValueProvider());
                    SessionHelper.Set(SessionKeys.Pessoa, empresa);
                    gerenciador.Editar(empresa);
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Empresa empresa = gerenciador.ObterEmpresa(id);
                    if (empresa != null)
                        return View(empresa);
                }
                return RedirectToAction("ListagemDistribuidoras");
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Empresa empresa = new Empresa();
                    TryUpdateModel<Empresa>(empresa, collection.ToValueProvider());
                    gerenciador.Editar(empresa);
                    return RedirectToAction("ListagemDistribuidoras");
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Empresa empresa = gerenciador.ObterEmpresa(id);
                    if (empresa != null)
                        return View(empresa);
                }
                return RedirectToAction("ListagemDistribuidoras");
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Remover(new Empresa { Id = id });
                    return RedirectToAction("ListagemDistribuidoras");
                }
                return View();
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar remover o objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar remover objeto.", e);
            }
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.USUARIO)]
        public ActionResult ListagemDistribuidoras()
        {
            try
            {
                List<Empresa> empresas = gerenciador.ObterEmpresas();
                if (empresas == null || empresas.Count == 0)
                    empresas = null;
                return View(empresas);
            }
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", e);
            }
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
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
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
        public ActionResult AlterarSenha(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Empresa empresa = (Empresa)SessionHelper.Get(SessionKeys.Pessoa);
                    String senha = Criptografia.GerarHashSenha(empresa.Login + collection["SenhaAtual"]);

                    if (senha.ToLowerInvariant().Equals(empresa.Senha.ToLowerInvariant()))
                    {
                        empresa.Senha = Criptografia.GerarHashSenha(empresa.Login + collection["NovaSenha"]);
                        SessionHelper.Set(SessionKeys.Pessoa, empresa);
                        empresa.ConfirmarSenha = empresa.Senha;
                        gerenciador.Editar(empresa);
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Senha incorreta.");
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
