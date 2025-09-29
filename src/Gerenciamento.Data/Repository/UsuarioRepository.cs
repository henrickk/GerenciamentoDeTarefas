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

        public async Task<Usuario> ObterUsuarioComProjetosETarefas(Guid id)
        {
            return await Db.Usuarios.AsNoTracking().Include(u => u.Projetos).Include( u => u.Tarefas).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return Db.Usuarios.AsNoTracking().FirstOrDefault(u => u.Email == email);
        }9

        public async Task<IEnumerable<Usuario>> ObterUsuariosComProjetosETarefasConcluidas()
        {
            return await Db.Usuarios.AsNoTracking().Include(u => u.Projetos).Include(u => u.Tarefas).ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterUsuariosComTarefas()
        {
            return await Db.Usuarios.AsNoTracking().Include(u => u.Tarefas).ToListAsync();
        }
    }
}
