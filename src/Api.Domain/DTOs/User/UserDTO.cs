using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(60, ErrorMessage = "O e-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}