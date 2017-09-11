using System;
using System.Collections.Generic;
using System.Linq;
using Model.Models;

namespace Persistencia.Persistence
{
   public  class RepositorioEmpresa
    {
        private static List<Empresa> listaEmpresa;

        static RepositorioEmpresa()
        {
            listaEmpresa = new List<Empresa>();
        }

        public Empresa Adicionar(Empresa empresa)
        {
            empresa.Id = listaEmpresa.Count + 1;
            listaEmpresa.Add(empresa);
            return empresa;
        }

        public void Editar(Empresa empresa)
        {
            int posicao = listaEmpresa.FindIndex(e => e.Id == empresa.Id);
            listaEmpresa[posicao] = empresa;
        }

        public void Remover(Empresa empresa)
        {
            int posicao = listaEmpresa.FindIndex(e => e.Id == empresa.Id);
            listaEmpresa.RemoveAt(posicao);
        }

        public Empresa Obter(Func<Empresa, bool> where)
        {
            return listaEmpresa.Where(where).FirstOrDefault();
        }

        public List<Empresa> ObterTodos()
        {
            return listaEmpresa;
        }
    }
}
