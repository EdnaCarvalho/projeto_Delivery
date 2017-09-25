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

        public void Editar(Pessoa pessoa)
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

        public void Remover(Pessoa pessoa)
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

        public Empresa ObterEmpresa(Func<Empresa, bool> where)
        {

            return listaEmpresa.Where(where).FirstOrDefault();
        }

        public Usuario ObterUsuario(Func<Usuario, bool> where)
        {
            return listaUsuario.Where(where).FirstOrDefault();
        }

        public List<Empresa> ObterEmpresas()
        {
            return listaEmpresa;
        }

        public List<Usuario> ObterUsuarios()
        {
            return listaUsuario;
        }
    }
}
