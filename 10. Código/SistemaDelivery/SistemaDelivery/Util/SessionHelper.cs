using System;
using System.Web;

namespace SistemaDelivery.Util
{
    public enum SessionKeys {Pessoa}

    public static class SessionHelper
    {
        public static object Get(SessionKeys chave)
        {
            String chaveString = Enum.GetName(typeof(SessionKeys),chave);
            return HttpContext.Current.Session[chaveString];
        }

        public static object Set(SessionKeys chave, object valor)
        {
            String chaveString = Enum.GetName(typeof(SessionKeys), chave);
            return HttpContext.Current.Session[chaveString] = valor;
        }
    }
}