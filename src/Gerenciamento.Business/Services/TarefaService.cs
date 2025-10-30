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


        public async Task Adicionar(Tarefa tarefa)
        {
            // Define a data de criação se não existir
            if (tarefa.DataCriacao == default)
                tarefa.DataCriacao = DateTime.Now;

            var tarefaExistente = await _tarefaRepository.Buscar(t => t.Titulo == tarefa.Titulo && t.ProjetoId == tarefa.ProjetoId);
            if (tarefaExistente.Any())
            {
                Notificar("Já existe uma tarefa com este título neste projeto.");
                return;
            }

            // Corrige DataConclusao inválida
            if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao.Value < new DateTime(1753, 1, 1))
                tarefa.DataConclusao = null;

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

            // Corrige DataConclusao inválida
            if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao.Value < new DateTime(1753, 1, 1))
                tarefa.DataConclusao = null;

            var tarefaDb = await _tarefaRepository.ObterPorId(tarefa.Id);
            if (tarefaDb == null)
            {
                Notificar("Tarefa não encontrada.");
                return;
            }
            tarefa.DataCriacao = tarefaDb.DataCriacao;

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
