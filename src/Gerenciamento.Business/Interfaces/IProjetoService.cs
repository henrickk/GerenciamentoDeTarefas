using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface IProjetoService : IDisposable
    {
        Task Adicionar(Projeto projeto);
        Task Atualizar(Projeto projeto);
        Task Remover(Guid id);
    }
}
