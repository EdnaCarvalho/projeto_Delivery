
namespace Model.Models
{
    public class ItemPedido
    {
        # region Atributos

        private int quantidade;
        private Produto produto;
        #endregion

        #region Propriedades

        
        public Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        # endregion
    }
}
