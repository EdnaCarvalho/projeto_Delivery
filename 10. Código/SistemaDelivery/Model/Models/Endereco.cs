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

        [Required(ErrorMessage = " Nome da cidade � obrigat�rio")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Cidade")]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        [Required(ErrorMessage = "O bairro � obrigat�rio")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Bairro")]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        [Required(ErrorMessage = "O endereco obrigat�rio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Por favor digitar o endere�o.")]
        [DataType(DataType.Text)]
        [Display(Name = "Endereco")]
        public string RuaAv
        {
            get { return ruaAv; }
            set { ruaAv = value; }
        }

        [Required(ErrorMessage = "O n�mero � obrigat�rio. Caso n�o tenha digitar S/N. ")]
        [StringLength(10, MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "N� ")]
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        [Required(ErrorMessage = "O estado � obrigat�rio.")]
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
    }
}