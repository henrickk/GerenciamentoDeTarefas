namespace Gerenciamento.Business.Models
{
    public class Projeto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }   
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid UsuarioId { get; set; } // Dono do projeto
        public Usuario Usuario { get; set; }
    }
}
