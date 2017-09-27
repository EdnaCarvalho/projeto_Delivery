using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Pessoa
    {
        #region Atributos

        private int id;
        private string nome;
        private string email;
        private string senha;
        private string confirmarSenha;
        private Endereco endereco;
        private string telefone;
        private string login;
        private List<Pedido> pedidos;

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage= "O nome completo é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Por favor digitar o nome completo.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Completo")]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email inválido.")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "O telefone é obrigatória.")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Digite apenas dígitos.")]
        [Display(Name = "Telefone")]
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha é obrigatória.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Deve possuir uma quantidade de caracteres entre 5 e 15.")]
        [RegularExpression(@"^[a-zA-Z0-9_@#$%&]{5,15}$", ErrorMessage = "Digite uma senha válida. Use letras, números e os caracteres especiais _ @ # $ % &.")]
        [DataType(DataType.Password)]
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmarSenha
        {
            get { return confirmarSenha; }
            set { confirmarSenha = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O login é obrigatório.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Deve possuir uma quantidade de caracteres entre 5 e 20.")]
        [RegularExpression(@"^[a-zA-Z0-9_]{5,20}$", ErrorMessage = "Digite um login válido. Use letras, números e underscore ( _ ).")]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [Required]
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public List<Pedido> Pedidos
        {
            get { return pedidos; }
            set { pedidos = value; }
        }

        #endregion
    }
}
