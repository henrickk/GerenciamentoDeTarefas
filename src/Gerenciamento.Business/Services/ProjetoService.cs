using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Services
{
    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IProjetoRepository _projetoRespository;

        public ProjetoService(IProjetoRepository projetoRespository, INotificador notificador) : base(notificador)
        {
            _projetoRespository = projetoRespository;
        }

        public async Task Adicionar(Projeto projeto)
        {
            var projetoExistente = await _projetoRespository.Buscar(p => p.Nome == projeto.Nome);
            if (projetoExistente.Any())
            {
                Notificar("Já existe um projeto com este nome.");
                return;
            }
            await _projetoRespository.Adicionar(projeto);
        }

        public async Task Atualizar(Projeto projeto)
        {
            var projetoExistente = await _projetoRespository.Buscar(p => p.Nome == projeto.Nome && p.Id != projeto.Id);
            if (projetoExistente.Any())
            {
                Notificar("Já existe um projeto com este nome.");
                return;
            }
        }

        public async Task Remover(Guid id)
        {
            await _projetoRespository.Remover(id);
        }

        public void Dispose()
        {
            _projetoRespository?.Dispose();
        }
    }
}
