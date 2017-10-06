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

        [Required(ErrorMessage = "O status é obrigatório")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "Total de dígitos incorreta.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Digite apenas dígitos.")]
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }


        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Total de dígitos incorreta.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Digite apenas dígitos.")]
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        [Required(ErrorMessage = "O nome do proprietario é obrigatório.")]
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