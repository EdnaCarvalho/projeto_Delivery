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

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(15, MinimumLength = 5)]
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, MinimumLength = 5)]
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Proprietário")]
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