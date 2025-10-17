using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.API.DTO
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public string ConfirmarSenha { get; set; }
    }
}
