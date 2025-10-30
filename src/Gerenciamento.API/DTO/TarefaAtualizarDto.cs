namespace Gerenciamento.API.DTO
{
    public class TarefaAtualizarDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; } // Responsável
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string Status { get; set; } = "Pendente"; // Pendente, Em Andamento, Concluída
        public string Prioridade { get; set; } = "Baixa"; // Baixa, Média, Alta
        public DateTime? DataConclusao { get; set; }
    }
}
