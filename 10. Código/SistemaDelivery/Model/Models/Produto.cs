using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Produto
    {

        #region Atributos

        private int id;
        private decimal preco;
        private int quantidade;
        private Empresa empresa;
        private TipoProduto tipoProduto;

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
       [Required (ErrorMessage = "O preço é obrigatório.")]
       [Display(Name = "Preço por Unidade")]
        public decimal Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        [Required (ErrorMessage = "A quantidade é obrigatório. Serve para controle de estoque.")]
        [Display(Name = "Quantidade do Produto")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]+$")]
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public TipoProduto TipoProduto
        {
            get { return tipoProduto; }
            set { tipoProduto = value; }
        }

        #endregion

    }
}