using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioPorEmail(string email);

        Task<Usuario> ObterUsuarioComProjetosETarefas(Guid id);

        Task<IEnumerable<Usuario>> ObterUsuariosComProjetosETarefas();

        Task<IEnumerable<Usuario>> ObterUsuariosComProjetos();

        Task<IEnumerable<Usuario>> ObterUsuariosComTarefas();

        Task<IEnumerable<Usuario>> ObterUsuariosComProjetosETarefasAtrasadas();

        Task<IEnumerable<Usuario>> ObterUsuariosComProjetosETarefasConcluidas();
    }
}
