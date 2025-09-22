using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IUsuarioService
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(Guid id);
    }
}