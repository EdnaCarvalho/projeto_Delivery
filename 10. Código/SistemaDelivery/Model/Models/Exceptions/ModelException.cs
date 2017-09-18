using System;

namespace Model.Models.Exceptions
{
    public class ModelException: AplicacaoException
    {
        public ModelException(string mensagem, Exception excecao) : base(mensagem, excecao) { }

        public ModelException(string mensagem) : base(mensagem) { }
    }
}
