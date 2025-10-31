using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefas()
        {
            return await Db.Tarefas.AsNoTracking()
                .Include(t => t.Usuario)
                .Include(t => t.Projeto)
                .ToListAsync();
        }

        public async Task<Tarefa> ObterPorId(Guid id)
        {
            return await Db.Tarefas.AsNoTracking()
                .Include(t => t.Usuario)
                .Include(t => t.Projeto)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tarefa> ObterTarefaProjetoUsuario(Guid id)
        {
            return await Db.Tarefas.AsNoTracking()
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasConcluidas()
        {
            return await Db.Tarefas.AsNoTracking()
                .Where(t => t.DataConclusao != null)
                .ToListAsync();

        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPendentes()
        {
            return await Db.Tarefas.AsNoTracking()
                .Where(t => t.DataConclusao == null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPorStatus(string status)
        {
            return await Db.Tarefas.AsNoTracking()
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPorUsuario(Guid usuarioId)
        {
            return await Db.Tarefas.AsNoTracking().Include(t => t.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
