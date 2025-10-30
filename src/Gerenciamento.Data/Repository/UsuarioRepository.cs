using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await Db.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await Db.Usuarios.AsNoTracking().FirstAsync(u => u.Id == id);
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return Db.Usuarios.AsNoTracking().FirstOrDefault(u => u.Email == email);
        }

        public async Task<Usuario> ObterComProjetosETarefas(Guid id)
        {
            return await Db.Usuarios.AsNoTracking().Include(u => u.Projetos).Include(u => u.Tarefas).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterComTarefas()
        {
            return await Db.Usuarios.AsNoTracking().Include(u => u.Tarefas).ToListAsync();
        }

        public Task<IEnumerable<Usuario>> ObterComProjetosETarefasConcluidas()
        {
            throw new NotImplementedException();
        }

        public async Task Inativar(Guid id)
        {
            var entity = await Db.Usuarios.FindAsync(id);
            if (entity == null) return; // ou Notificar

            entity.Ativo = false;
            await SaveChanges();
        }

        public async Task Atualizar(Usuario entity)
        {
            Db.Usuarios.Update(entity);
            await SaveChanges();
        }
    }
}
