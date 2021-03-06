﻿using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;
using Model.Models.Exceptions;
using System;

namespace SistemaDelivery.Controllers
{
    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR)]
    public class AdministradorController : Controller
    {

        private GerenciadorPessoa gerenciador;

        public AdministradorController()
        {
            gerenciador = new GerenciadorPessoa();
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }
        
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
                        Usuario usuario = new Usuario();
                        TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                        usuario.ConfirmarSenha = usuario.Senha;
                        gerenciador.Adicionar(usuario);
                        return RedirectToAction("ListagemUsuarios");
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
                throw new ControllerException("Erro ao tentar criar o objeto.", e);
            }
        }
        
        public ActionResult AlterarDados()
        {
            try
            {
                Usuario administrador = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (administrador != null)
                    return View(administrador);
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
        public ActionResult AlterarDados(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario administrador = new Usuario();
                    TryUpdateModel<Usuario>(administrador, collection.ToValueProvider());
                    SessionHelper.Set(SessionKeys.Pessoa, administrador);
                    gerenciador.Editar(administrador);
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
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = new Usuario();
                    TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());
                    gerenciador.Editar(usuario);
                    return RedirectToAction("ListagemUsuarios");
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar remover o objeto.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar remover o objeto.", e);
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
            catch (NegocioException n)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", n);
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter os objetos.", e);
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

        [HttpPost]
        public ActionResult AlterarSenha(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario administrador = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                    String senha = Criptografia.GerarHashSenha(administrador.Login + collection["SenhaAtual"]);

                    if (senha.ToLowerInvariant().Equals(administrador.Senha.ToLowerInvariant()))
                    {
                        administrador.Senha = Criptografia.GerarHashSenha(administrador.Login + collection["NovaSenha"]);
                        administrador.ConfirmarSenha = administrador.Senha;
                        SessionHelper.Set(SessionKeys.Pessoa, administrador);
                        gerenciador.Editar(administrador);
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
