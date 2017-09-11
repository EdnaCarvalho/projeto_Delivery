using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Pedido
    {

        #region Atributos

        private int id;
        private Empresa empresa;
        private Usuario cliente;
        private List<Produto> produtos;
        private DateTime dataRealizacao;
        private DateTime dataFinalizacao;
        private string descricao;
        private string status;
        private string enderecoEntrega;
        private List<Notificacao> notificacoes;

        #endregion

        #region Propriedades

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        [Required]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        
        public Usuario Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        
        public List<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }

        [Range(typeof(DateTime), "1/1/2017", "31/12/2030")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataRealizacao
        {
            get { return dataRealizacao; }
            set { dataRealizacao = value; }
        }

        [Range(typeof(DateTime), "1/1/2017", "31/12/2018")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataFinalizacao
        {
            get { return dataFinalizacao; }
            set { dataFinalizacao = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        [Required]
        public string EnderecoEntrega
        {
            get { return enderecoEntrega; }
            set { enderecoEntrega = value; }
        }

        public List<Notificacao> Notificacoes
        {
            get { return notificacoes; }
            set { notificacoes = value; }
        }

        #endregion

        #region Construtor

        public Pedido()
        {
            Empresa = null;   
            Cliente = null;
            status = null;
            Produtos = new List<Produto>();
            Notificacoes = new List<Notificacao>();
            DataRealizacao = DateTime.Now;
            DataFinalizacao = DateTime.Now;
            Descricao = null;
            EnderecoEntrega = null;
            Notificacoes = null;
        }

        #endregion

    }
}