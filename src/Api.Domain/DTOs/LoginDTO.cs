using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para login!")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido!")]
        [StringLength(100, ErrorMessage = "Email deve ter no mínimo{1} caracteres!")]
        public string Email { get; set; }
    }
}