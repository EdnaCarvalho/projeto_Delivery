using System;

namespace Model.Models.Exceptions
{
   public class NegocioException : AplicacaoException
    {
        public NegocioException(string mensagem, Exception excecao) : base(mensagem, excecao) { }

        public NegocioException(string mensagem) : base(mensagem) { }
    }
}
