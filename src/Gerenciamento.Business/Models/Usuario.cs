using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Models
{
    public class Usuario : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        public string Role { get; set; } = "User";
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; } = true;
        public ICollection<Projeto> Projetos { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
