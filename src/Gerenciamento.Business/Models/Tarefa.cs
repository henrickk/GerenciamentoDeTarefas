namespace Gerenciamento.Business.Models
{
    public class Tarefa : Entity
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
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
