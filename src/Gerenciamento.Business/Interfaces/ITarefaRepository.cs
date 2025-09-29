using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTarefaProjetoUsuario(Guid id);

        Task<IEnumerable<Tarefa>> ObterTarefasPorUsuario(Guid usuarioId);

        Task<IEnumerable<Tarefa>> ObterTarefasConcluidas();

        Task<IEnumerable<Tarefa>> ObterTarefasPendentes();

        Task<IEnumerable<Tarefa>> ObterTarefasPorStatus(string status);
    }
}
