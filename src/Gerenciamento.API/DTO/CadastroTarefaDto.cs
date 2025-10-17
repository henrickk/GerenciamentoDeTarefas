using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gerenciamento.API.DTO
{
    public class CadastroTarefaDto
    {
        public Guid ProjetoId { get; set; }
        public Guid UsuarioId { get; set; } // Responsável
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public string Status { get; set; } = "Pendente"; // Pendente, Em Andamento, Concluída

        public string Prioridade { get; set; } = "Baixa"; // Baixa, Média, Alta

        [JsonIgnore]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime DataConclusao { get; set; } = DateTime.Now.AddDays(7);

    }
}
