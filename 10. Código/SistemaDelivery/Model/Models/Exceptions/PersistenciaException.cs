using System;

namespace Model.Models.Exceptions
{
    public class PersistenciaException : AplicacaoException
    {
        public PersistenciaException(string mensagem, Exception excecao) : base(mensagem, excecao) { }

        public PersistenciaException(string mensagem) : base(mensagem) { }
    }
}
