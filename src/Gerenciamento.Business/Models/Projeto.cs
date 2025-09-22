namespace Projeto.Business.Models
{
    public class Projeto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public Usuario Usuario { get; set; }
    }
}
