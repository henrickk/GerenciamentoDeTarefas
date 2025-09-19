namespace Projeto.Business.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<string> Status { get; set; }
        public List<string> Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }

        public Projeto Projeto { get; set; }
        public Projeto ProjetId { get; set; }

        public Usuario Usuario { get; set; }
        public Usuario UsuarioId { get; set; }
    }
}
