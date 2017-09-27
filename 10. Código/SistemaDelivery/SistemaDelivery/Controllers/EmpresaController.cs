using System.Collections.Generic;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SistemaDelivery.Util;

namespace SistemaDelivery.Controllers

{
    [Authenticated]
    [CustomAuthorize(NivelAcesso = Util.TipoUsuario.EMPRESA)]
    public class EmpresaController : Controller
    {
        private GerenciadorPessoa gerenciador;

        public EmpresaController ()
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
                    Empresa empresa = gerenciador.ObterEmpresa(id);
                    if (empresa != null)
                        return View(empresa);
                }
                return RedirectToAction("Index");
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
                        Usuario empresa = new Usuario();
                        TryUpdateModel<Pessoa>(empresa, collection.ToValueProvider());
                        gerenciador.Adicionar(empresa);
                        return RedirectToAction("ListagemDistribuidoras");
                    }
                    ModelState.AddModelError("", "Login já existente.");
                   
                }
                return View();
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro na criação do objeto.", e);
            }
          
        }

        public ActionResult AlterarDados()
        {
            try
            {
                Usuario empresa = (Usuario)SessionHelper.Get(SessionKeys.Pessoa);
                if (empresa != null)
                    return View(empresa);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
            
        }

        [HttpPost]
       public ActionResult AlterarDados(Usuario empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SessionHelper.Set(SessionKeys.Pessoa,empresa);
                    gerenciador.Editar(empresa);
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
                    Empresa empresa = gerenciador.ObterEmpresa(id);
                    if (empresa != null)
                        return View(empresa);
                }
                return RedirectToAction("ListagemDistribuidoras");
            }
            catch (Exception e)
            {
                throw new ControllerException("Erro ao tentar obter as informações do objeto.", e);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gerenciador.Editar(empresa);
                    return RedirectToAction("ListagemDistribuidoras");
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
                    Empresa empresa = gerenciador.ObterEmpresa(id);
                    if (empresa != null)
                        return View(empresa);
                }
                return RedirectToAction("ListagemDistribuidoras");
            }
            catch(Exception e)
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
                    gerenciador.Remover(new Empresa { Id = id });
                    return RedirectToAction("ListagemDistribuidoras");
                }
                return View();
            }
            catch ( Exception e)
            {
                throw new ControllerException("Erro ao tentar remover objeto.", e);
            }
            
        }
        public ActionResult ListagemDistribuidoras()
        {

            try
            {
                List<Empresa> empresa = gerenciador.ObterEmpresas().Where(u => u.Id != ((Empresa)SessionHelper.Get(SessionKeys.Pessoa)).Id).ToList();
                if (empresa == null || empresa.Count == 0)
                    empresa = null;
                return View(empresa);
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
                    Pessoa empresa = SessionHelper.Get(SessionKeys.Pessoa) as Pessoa;
                    String senha = Criptografia.GerarHashSenha(administrador.Login + collection["SenhaAtual"]);

                    if (senha.ToLowerInvariant().Equals(empresa.Senha.ToLowerInvariant()))
                    {
                        empresa.Senha = Criptografia.GerarHashSenha(administrador.Login + collection["NovaSenha"]);
                        SessionHelper.Set(SessionKeys.Pessoa, empresa);
                        gerenciador.Editar(empresa);
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
