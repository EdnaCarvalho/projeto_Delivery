using System;

namespace Model.Models.Exceptions
{
    public class ViewException : AplicacaoException
    {
        public ViewException(string mensagem, Exception excecao) : base(mensagem, excecao) { }

        public ViewException(string mensagem) : base(mensagem) { }
    }
}
