using System;

namespace Model.Models.Exceptions
{
    public class AplicacaoException :Exception
    {
        public AplicacaoException(string mensagem, Exception excecao) : base(mensagem, excecao) { }

        public AplicacaoException(string mensagem) : base(mensagem) { }
    }
}
