using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();

        Task<Usuario> ObterUsuarioPorEmail(string email);

        Task<Usuario> ObterUsuarioComProjetosETarefas(Guid id);

        Task<IEnumerable<Usuario>> ObterUsuariosComTarefas();

        Task<IEnumerable<Usuario>> ObterUsuariosComProjetosETarefasConcluidas();
    }
}
