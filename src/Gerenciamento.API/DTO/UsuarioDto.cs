using Gerenciamento.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.API.DTO
{
    public class UsuarioDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "SenhaHash")]

        public string SenhaHash { get; set; }

        public string Role { get; set; } = "User";

        public DateTime DataCadastro { get; set; }
    }
}
