using Entidades.Notificacoes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Entidades
{
    [Table("TB_PRODUTO")]
    public class Produto : Notifica
    {
        [Column("PROD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PROD_NOME")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("PROD_DESCRICAO")]
        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Column("PROD_OBSERVACAO")]
        [Display(Name = "Observacao")]
        [MaxLength(2000)]
        public string Observacao { get; set; }

        [Column("PROD_VALOR")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("PROD_QTD_ESTOQUE")]
        [Display(Name = "Quantiade de Estoque")]
        public int QtdEstoque { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("UsuarioAplicacao")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual UsuarioAplicacao UsuarioAplicacao { get; set; }

        [Column("PROD_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Column("PROD_DATA_CADASTRO")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("PROD_DATA_ALTERACAO")]
        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [NotMapped]
        public int IdProdutoCarrinho { get; set; }

        [NotMapped]
        public int QtdCompra { get; set; }

        [NotMapped]
        public IFormFile Imagem { get; set; }

        [Column("PROD_URL")]
        public string Url { get; set; }
    }
}




