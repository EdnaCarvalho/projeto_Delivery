using System;
using System.Collections.Generic;
using System.Linq;

using Model.App_GlobalResources;
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

        [Required(ErrorMessageResourceName = "NomeRequerido", ErrorMessageResourceType = typeof(Mensagens))]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome Completo")]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [Required(ErrorMessageResourceName = "EmailRequerido", ErrorMessageResourceType = typeof(Mensagens))]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
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

        [Required(ErrorMessageResourceName = "SenhaRequerida", ErrorMessageResourceType = typeof(Mensagens))]
        [StringLength(10, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Za-z0-9_]+$")]
        [Display(Name = "Senha")]
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        [Required(ErrorMessageResourceName = "SenhaDiferente", ErrorMessageResourceType = typeof(Mensagens))]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmarSenha
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

        [Required(ErrorMessageResourceName = "LoginRequerido", ErrorMessageResourceType = typeof(Mensagens))]
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

        #endregion
    }
}
