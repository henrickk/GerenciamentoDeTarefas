using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(Guid id);
    }
}
