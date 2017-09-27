using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using Model.Models.Exceptions;
using System;

namespace SistemaDelivery.Controllers
{
    public class AdministradorController : Controller
    {

        private GerenciadorPessoa gerenciador;


        public AdministradorController()
        {
            gerenciador = new GerenciadorPessoa();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Usuario usuario = gerenciador.ObterUsuario(id);
                    if (usuario != null)
                        return View(usuario);
                }
                return RedirectToAction("ListagemUsuarios");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Adicionar(administrador);
                    return RedirectToAction("ListagemUsuarios");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro na criação do objeto.", e);
            }
        }

        public ActionResult AlterarDados(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Usuario administrador = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                    if (administrador != null)
                        return View(administrador);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }


        [HttpPost]
        public ActionResult AlterarDados(int id, Usuario administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SessionHelper.Set(SessionKeys.Pessoa, administrador);
                    gerenciador.Editar(administrador);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Usuario usuario = gerenciador.ObterUsuario(id);
                    if (usuario != null)
                        return View(usuario);
                }
                return RedirectToAction("ListagemUsuarios");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(usuario);
                    return RedirectToAction("ListagemUsuarios");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar alterar as informações do objeto.", e);
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Usuario usuario = gerenciador.ObterUsuario(id);
                    if (usuario != null)
                        return View(usuario);
                }
                return RedirectToAction("ListagemUsuarios");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Remover(new Usuario { Id = id });
                    return RedirectToAction("ListagemUsuarios");
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar remover objeto.", e);
            }
        }

        public ActionResult ListagemUsuarios()
        {
            try
            {
                List<Usuario> usuarios = gerenciador.ObterUsuarios().Where(u => u.Id != ((Usuario)SessionHelper.Get(SessionKeys.Pessoa)).Id).ToList();
                if (usuarios == null || usuarios.Count == 0)
                    usuarios = null;
                return View(usuarios);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", e);
            }
        }
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa administrador = SessionHelper.Get(SessionKeys.Pessoa) as Pessoa;
                    String senha = Criptografia.GerarHashSenha(administrador.Login + collection["SenhaAtual"]);

                    if (senha.ToLowerInvariant().Equals(administrador.Senha.ToLowerInvariant()))
                    {
                        administrador.Senha = Criptografia.GerarHashSenha(administrador.Login + collection["NovaSenha"]);
                        SessionHelper.Set(SessionKeys.Pessoa, administrador);
                        gerenciador.Editar(administrador);
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Senha incorreta.");
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
