using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RH360.Data.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO() { }
        [Key]
        public int UserID { get; set; }

        [StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres.")]
        public string Nome { get; set; } = "";
        
        [StringLength(75, ErrorMessage = "O e-mail deve ter no máximo 75 caracteres.")]
        public string EmailUser { get; set; } = "";

        [StringLength(6, ErrorMessage = "A senha deve ter no máximo 6 caracteres.")]
        public string Senha { get; set; } = "";

        [Required(ErrorMessage = "O campo Termos é obrigatório.")]
        public bool Termos { get; set; } = false;

        [StringLength(50, ErrorMessage = "O tipo de empresa deve ter no máximo 50 caracteres.")]
        public string TipoEmpresa { get; set; } = "";
        
        [Required(ErrorMessage = "O campo NomeEmpresa é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome da empresa deve ter no máximo 255 caracteres.")]
        public string NomeEmpresa { get; set; } = "";
        
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CNPJ deve ter no máximo 14 caracteres.")]
        public string CNPJ { get; set; } = "";
        
        [StringLength(8, ErrorMessage = "O CEP deve ter no máximo 8 caracteres.")]
        public string CEP { get; set; } = "";

        [StringLength(255, ErrorMessage = "O endereço deve ter no máximo 255 caracteres.")]
        public string Endereco { get; set; } = "";
        
        [StringLength(50, ErrorMessage = "O bairro deve ter no máximo 50 caracteres.")]
        public string Bairro { get; set; } = "";

        [StringLength(2, ErrorMessage = "O estado deve ter no máximo 2 caracteres.")]
        public string Estado { get; set; } = "";

        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; } = "";
        
        [StringLength(50, ErrorMessage = "O complemento deve ter no máximo 50 caracteres.")]
        public string Complemento { get; set; } = "";
        
        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [StringLength(11, ErrorMessage = "O celular deve ter no máximo 11 caracteres.")]
        public string Celular { get; set; } = "";

        [Required(ErrorMessage = "O campo NomeAdm é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome do administrador deve ter no máximo 255 caracteres.")]
        public string NomeAdm { get; set; } = "";

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string CPF { get; set; } = "";

        [Required(ErrorMessage = "O campo Email da empresa é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [StringLength(75, ErrorMessage = "O e-mail da empresa deve ter no máximo 75 caracteres.")]
        public string EmailEmpresa { get; set; } = "";

    }
}

