using System.ComponentModel.DataAnnotations;

namespace Model.Models

{
    public class Notificacao
    {
        #region Atributos

        private int id;
        private string status;
        private string descricao;
        private Pedido pedido;

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [Required]
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        [Required]
        public Pedido Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }

        #endregion

        #region Construtor

        public Notificacao()
        {
            Status = null;
            Descricao = null;
            Pedido = null;
        }

        #endregion
    }
}