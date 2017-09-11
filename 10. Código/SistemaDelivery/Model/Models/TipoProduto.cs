using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class TipoProduto
    {        

        #region Atributos

        private int id;
        private string marca;
        private string tipo;
        private string descricao;

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        [Display(Name = "Marca do Produto")]
        [DataType(DataType.Text)]
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        [Required]
        [Display(Name = "Tipo do Produto")]
        [DataType(DataType.Text)]
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        [Required]
        [Display(Name = "Descri��o do Produto")]
        [DataType(DataType.Text)]
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        #endregion

        #region Construtor

        public TipoProduto()
        {
            Marca = null;
            Tipo = null;
            Descricao = null;
        }

        #endregion
    }
}