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
        private DateTime dataRealizacao;
        private DateTime? dataFinalizacao;
        private string descricao;
        private string status;
        private Endereco enderecoEntrega;
        private List<Notificacao> notificacoes;
        private List<ItemPedido> itens;

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
        
       
        [Range(typeof(DateTime), "1/1/2017", "31/12/2030")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataRealizacao
        {
            get { return dataRealizacao; }
            set { dataRealizacao = value; }
        }

        [Range(typeof(DateTime), "1/1/2017", "31/12/2018")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DataFinalizacao
        {
            get { return dataFinalizacao; }
            set { dataFinalizacao = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        
        public Endereco EnderecoEntrega
        {
            get { return enderecoEntrega; }
            set { enderecoEntrega = value; }
        }

        public List<Notificacao> Notificacoes
        {
            get { return notificacoes; }
            set { notificacoes = value; }
        }

        public List<ItemPedido> Itens
        {
            get { return itens; }
            set { itens = value; }
        }
        #endregion

    }
}