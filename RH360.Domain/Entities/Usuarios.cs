﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RH360.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario() { }

        [Key]
        public int UserID { get; set; }

        public string Nome { get; set; } = "";

        public string EmailUser { get; set; } = "";

        public string Senha { get; set; } = "";

        public bool Termos { get; set; } = false;

        public string TipoEmpresa { get; set; } = "";
       
        public string NomeEmpresa { get; set; } = "";
        
        public string CNPJ { get; set; } = "";

        public string CEP { get; set; } = "";

        public string Endereco { get; set; } = "";

        public string Bairro { get; set; } = "";

        public string Estado { get; set; } = "";

        public string Cidade { get; set; } = "";

        public string Complemento { get; set; } = "";

        public string Celular { get; set; } = "";

        public string NomeAdm { get; set; } = "";

        public string CPF { get; set; } = "";

        public string EmailEmpresa { get; set; } = "";

    }
}
