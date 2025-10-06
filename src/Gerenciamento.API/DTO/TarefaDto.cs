using Gerenciamento.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.API.DTO
{
    public class TarefaDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public string NomeUsuario { get; set; }

        public string Status { get; set; } // Pendente, Em Andamento, Concluída

        public string Prioridade { get; set; } // Baixa, Média, Alta

        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public Guid ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public Guid UsuarioId { get; set; } // Responsável
        public Usuario Usuario { get; set; }
    }
}
