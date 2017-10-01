using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{

    public class Empresa : Pessoa
    {

        #region Atributos

        private string cnpj;
        private string cpf;
        private string proprietario;
        private string status;
        private List<Produto> produtos;

        #endregion

        #region Propriedades

        [Required(ErrorMessage = "O status � obrigat�rio")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [Required(ErrorMessage = "O CPF � obrigat�rio")]
        [StringLength(11, ErrorMessage = "Total de d�gitos incorreta.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Digite apenas d�gitos.")]
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }


        [Required(ErrorMessage = "O CNPJ � obrigat�rio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Total de d�gitos incorreta.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Digite apenas d�gitos.")]
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        [Required(ErrorMessage = "O nome do proprietario � obrigat�rio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Por favor digitar o nome completo.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Completo")]
        public string Proprietario
        {
            get { return proprietario; }
            set { proprietario = value; }
        }

        public List<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }

        #endregion
        
    }
}