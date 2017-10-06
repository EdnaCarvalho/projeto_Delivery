using System;

namespace Model.Models.Exceptions
{
   public class ControllerException : AplicacaoException
    {
        public ControllerException(string mensagem, Exception excecao) : base(mensagem, excecao) { }

        public ControllerException(string mensagem) : base(mensagem) { }
    }
}
