using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto> ObterProjetoUsuario(Guid id);

        Task<IEnumerable<Projeto>> ObterProjetosComTarefas();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasEUsuarios();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasConcluidas();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasPorPrioridade(string prioridade);
    }
}
