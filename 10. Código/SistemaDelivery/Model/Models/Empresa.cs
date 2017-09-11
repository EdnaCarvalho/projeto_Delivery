using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Models{

    public class Empresa {

        #region Atributos

        private int id;
        private string nome;
        private string email;
        private string senha;
        private string confirmarSenha;
        private Endereco endereco;
        private string telefone;
        private string cnpj;
        private string cpf;
        private string proprietario;
        private string login;
        private string status;
        private List<Pedido> pedidos;
        private List<Produto> produtos;

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Telefone")]
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Empresa:")]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

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
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email
        {           
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(10, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Za-z0-9_]+$")]
        [Display(Name = "Senha")]
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmar Senha")]
        public String ConfirmarSenha
        {
            get { return confirmarSenha; }
            set { confirmarSenha = value; }
        }

        [Required]
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
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

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public List<Pedido> Pedidos
        {
            get { return pedidos; }
            set { pedidos = value; }
        }

        public List<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }

        #endregion

        #region Construtor

        public Empresa()
        {
            Nome = null;
            Email = null;
            Senha = null;
            Endereco = null;
            Cnpj = null;
            Proprietario = null;
            Status = null;
            Cpf = null;
            Login = null;
            Pedidos = new List<Pedido>();
            Produtos = new List<Produto>();
        }
         #endregion

    }
}