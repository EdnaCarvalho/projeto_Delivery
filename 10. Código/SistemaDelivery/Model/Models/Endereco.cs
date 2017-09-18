using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Endereco
    {
        #region Atributos

        private string cidade;
        private string bairro;
        private string ruaAv;
        private string numero;        
        private string estado;

        #endregion

        #region Propriedades

        [Required(ErrorMessage = " Nome da cidade é obrigatório")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Cidade")]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Bairro")]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        [Required(ErrorMessage = "O endereco obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Por favor digitar o endereço.")]
        [DataType(DataType.Text)]
        [Display(Name = "Endereco")]
        public string RuaAv
        {
            get { return ruaAv; }
            set { ruaAv = value; }
        }

        [Required(ErrorMessage = "O número é obrigatório. Caso não tenha digitar S/N. ")]
        [StringLength(10, MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Nº ")]
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "Digitar apenas o UF do estado.")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Za-z]+$")]
        [Display(Name = "UF")]
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion

        #region Construtor

        public Endereco()
        {
            Cidade = null;
            Bairro = null;
            RuaAv = null;
            Numero = null;
            Estado = null;
        }

       #endregion
    }
}