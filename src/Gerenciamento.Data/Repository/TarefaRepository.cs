using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(MeuDbContext context) : base(context) { 
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefas()
        {
            return await Db.Tarefas.AsNoTracking().ToListAsync();
        }

        public async Task<Tarefa> ObterTarefaProjetoUsuario(Guid id)
        {
            return await Db.Tarefas.AsNoTracking().Include(t => t.Usuario).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasConcluidas()
        {
            return await Db.Tarefas.AsNoTracking().Include(t => t.DataConclusao).ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPendentes()
        {
            return (IEnumerable<Tarefa>)Db.Tarefas.AsNoTracking().Include(t => t.DataCriacao == null).ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPorStatus(string status)
        {
            return await Db.Tarefas.AsNoTracking().Include(status).ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefasPorUsuario(Guid usuarioId)
        {
            return await Db.Tarefas.AsNoTracking().Include(t => t.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
