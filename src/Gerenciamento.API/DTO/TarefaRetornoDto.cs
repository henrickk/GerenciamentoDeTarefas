using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.API.DTO
{
    public class TarefaRetornoDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; } // Responsável

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public string NomeUsuario { get; set; } = string.Empty;

        public string Status { get; set; } // Pendente, Em Andamento, Concluída

        public string Prioridade { get; set; } // Baixa, Média, Alta

        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Guid ProjetoId { get; set; }

        public string NomeProjeto { get; set; } = string.Empty;

    }
}
