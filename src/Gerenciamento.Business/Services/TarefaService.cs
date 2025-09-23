using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository, INotificador notificador) : base(notificador)
        {
            _tarefaRepository = tarefaRepository;
        }

        //Não permitir 2 tarefas iguais no mesmo projeto
        public async Task Adicionar(Tarefa tarefa)
        {
            var tarefaExistente = await _tarefaRepository.Buscar(t => t.Titulo == tarefa.Titulo && t.ProjetoId == tarefa.ProjetoId);
            if (tarefaExistente.Any())
            {
                Notificar("Já existe uma tarefa com este título neste projeto.");
                return;
            }
            await _tarefaRepository.Adicionar(tarefa);
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            var tarefaExistente = await _tarefaRepository.Buscar(t => t.Titulo == tarefa.Titulo && t.ProjetoId == tarefa.ProjetoId && t.Id != tarefa.Id);
            if (tarefaExistente.Any())
            {
                Notificar("Já existe uma tarefa com este título neste projeto.");
                return;
            }
            await _tarefaRepository.Atualizar(tarefa);
        }

        public async Task Remover(Guid id)
        {
            await _tarefaRepository.Remover(id);
        }

        public void Dispose()
        {
            _tarefaRepository?.Dispose();
        }
    }
}
