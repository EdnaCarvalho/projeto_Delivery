using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Produto
    {

        #region Atributos

        private int id;
        private double preco;
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
        [Display(Name = "Preco por Unidade")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Preco
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