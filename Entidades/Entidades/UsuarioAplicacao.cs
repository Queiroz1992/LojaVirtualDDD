using Entidades.Entidades.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Entidades
{
    public class UsuarioAplicacao : IdentityUser
    {
        [Column("USUARIO_CPF")]
        [MaxLength(50)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("USUARIO_IDADE")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Column("USUARIO_NOME")]
        [MaxLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("USUARIO_CEP")]
        [MaxLength(15)]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Column("USUARIO_ENDERECO")]
        [MaxLength(255)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Column("USUARIO_COMPLEMENTO_ENDERECO")]
        [MaxLength(450)]
        [Display(Name = "Complemento de Endereço")]
        public string ComplementoEndereco { get; set; }

        [Column("USUARIO_CELULAR")]
        [MaxLength(20)]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Column("USUARIO_TELEFONE")]
        [MaxLength(20)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Column("USUARIO_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Column("USUARIO_TIPO")]
        [Display(Name = "Tipo")]
        public TipoUsuario? Tipo { get; set; }
    }
}
