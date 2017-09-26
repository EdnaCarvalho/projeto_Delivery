using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Model.Models.Exceptions;
namespace Persistencia.Persistence
{
    public class RepositorioPessoa
    {
        private static List<Usuario> listaUsuario;
        private static List<Empresa> listaEmpresa;

        static RepositorioPessoa()
        {
            listaUsuario = new List<Usuario>();
            listaEmpresa = new List<Empresa>();
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            try
            {
                if (pessoa.GetType() == typeof(Usuario))
                {
                    pessoa.Id = listaUsuario.Count + 1;
                    listaUsuario.Add((Usuario)pessoa);
                }
                else
                {
                    pessoa.Id = listaEmpresa.Count + 1;
                    listaEmpresa.Add((Empresa)pessoa);
                }
                return pessoa;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar adicionar objeto.", e);
            }
        }

        public void Editar(Pessoa pessoa)
        {
            try
            {

                if (pessoa.GetType() == typeof(Usuario))
                {
                    int posicao = listaUsuario.FindIndex(e => e.Id == pessoa.Id);
                    listaUsuario[posicao] = (Usuario)pessoa;
                }
                else
                {
                    int posicao = listaEmpresa.FindIndex(e => e.Id == pessoa.Id);
                    listaEmpresa[posicao] = (Empresa)pessoa;
                }
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro na edição do objeto.", e);
            }
        }

        public void Remover(Pessoa pessoa)
        {
            try
            {
                if (pessoa.GetType() == typeof(Usuario))
                {
                    int posicao = listaUsuario.FindIndex(e => e.Id == pessoa.Id);
                    listaUsuario.RemoveAt(posicao);
                }
                else
                {
                    int posicao = listaEmpresa.FindIndex(e => e.Id == pessoa.Id);
                    listaEmpresa.RemoveAt(posicao);
                }
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar remover objeto.", e);
            }
        }

        public Empresa ObterEmpresa(Func<Empresa, bool> where)
        {
            try
            {
                return listaEmpresa.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter objeto.", e);
            }
        }

        public Usuario ObterUsuario(Func<Usuario, bool> where)
        {
            try
            {
                return listaUsuario.Where(where).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter objeto.", e);
            }
        }

        public List<Empresa> ObterEmpresas()
        {
            try
            {
                return listaEmpresa;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter os objetos.", e);
            }
        }

        public List<Usuario> ObterUsuarios()
        {
            try
            {
                return listaUsuario;
            }
            catch (Exception e)
            {
                throw new PersistenciaException("Erro ao tentar obter os objetos.", e);
            }
        }
    }
}
