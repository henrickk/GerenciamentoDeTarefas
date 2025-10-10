namespace Gerenciamento.Business.Models
{
    public class Projeto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? DataConclusao { get; set; }
        public Guid UsuarioId { get; set; } // Dono do projeto
        public Usuario Usuario { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }


        public void ConcluirProjeto()
        {
            if (!FoiConcluido())
            {
                DataConclusao = DateTime.Now;
            }
        }

        public bool FoiConcluido()
        {
            return DataConclusao.HasValue;
        }
    }
}
