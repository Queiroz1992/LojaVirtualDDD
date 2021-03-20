using Entidades.Entidades.Enums;
using Entidades.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Entidades
{
    [Table("TB_COMPRA_USUARIO")]
    public class CompraUsuario : Notifica
    {
        [Column("COMPRA_USUARIO_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("TB_PRODUTO")]
        [Column(Order = 1)]
        public int IdProduto { get; set; }

        public virtual Produto Produto { get; set; }

        [Column("COMPRA_USUARIO_ESTADO")]
        [Display(Name = "Estado")]
        public EstadoCompra Estado { get; set; }

        [Column("COMPRA_USUARIO_QTD")]
        [Display(Name = "Quantidade")]
        public int QtdCompra { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("UsuarioAplicacao")]
        public string UserId { get; set; }

        public virtual UsuarioAplicacao UsuarioAplicacao { get; set; }

        [NotMapped]
        [Display(Name = "Quantidade Total")]
        public int QuantidadeProdutos { get; set; }

        [NotMapped]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }

        [NotMapped]
        [Display(Name = "Endereço de entrega")]
        public string EnderecoCompleto { get; set; }

        [NotMapped]
        public List<Produto> ListaProdutos { get; set; }

    }
}
