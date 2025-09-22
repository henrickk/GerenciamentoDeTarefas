using Projeto.Business.Models;

namespace Projeto.Business.Interfaces
{
    public interface ITarefaService
    {
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(Guid id);
    }
}
