using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;

namespace Gerenciamento.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.Buscar(u => u.Email == usuario.Email);
            if (usuarioExistente.Any())
            {
                Notificar("Já existe um usuário com este email.");
                return;
            }
            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.Buscar(u => u.Email == usuario.Email && u.Id != usuario.Id);
            if (usuarioExistente.Any())
            {
                Notificar("Já existe um usuário com este email.");
                return;
            }
            await _usuarioRepository.Atualizar(usuario);
        }

        public async Task Inativar(Guid id)
        {
            await _usuarioRepository.Inativar(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
