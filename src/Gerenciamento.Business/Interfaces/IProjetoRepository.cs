using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto> ObterProjetoUsuario(Guid id);
        Task<Projeto> ObterProjetoTarefasUsuarios(Guid id);

        Task<IEnumerable<Projeto>> ObterProjetosPorUsuario(Guid usuarioId);

        Task<IEnumerable<Projeto>> ObterProjetosComTarefas();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasEUsuarios();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasAtrasadas();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasConcluidas();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasPendentes();

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasPorStatus(string status);

        Task<IEnumerable<Projeto>> ObterProjetosComTarefasPorPrioridade(string prioridade);


    }
}
