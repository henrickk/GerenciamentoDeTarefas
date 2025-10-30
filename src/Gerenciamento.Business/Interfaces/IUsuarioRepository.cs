using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();

        Task<Usuario> ObterPorId(Guid id);

        Task<Usuario> ObterPorEmail(string email);

        Task<Usuario> ObterComProjetosETarefas(Guid id);

        Task<IEnumerable<Usuario>> ObterComTarefas();

        Task<IEnumerable<Usuario>> ObterComProjetosETarefasConcluidas();

        Task Inativar(Guid id);

        Task Atualizar(Usuario entity);

    }
}
