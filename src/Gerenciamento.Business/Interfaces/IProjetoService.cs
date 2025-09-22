using Gerenciamento.Business.Interfaces;

namespace Gerenciamento.Business.Interfaces
{
    public interface IProjetoService
    {
        Task Adicionar(Projeto projeto);
    }
}
