using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento.Data.Repository
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Projeto>> ObterProjetosComTarefas()
        {
            return await Db.Projetos.AsNoTracking()
                .Include(p => p.Tarefas)
                .ToListAsync();
        }

        public async Task<IEnumerable<Projeto>> ObterProjetos()
        {
            return await Db.Projetos.AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.Tarefas)
                    .ThenInclude(t => t.Usuario)
                .ToListAsync();
        }

        public override async Task<Projeto?> ObterPorId(Guid id)
        {
            return await Db.Projetos.AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.Tarefas)
                    .ThenInclude(t => t.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Projeto>> ObterProjetosComTarefasConcluidas()
        {
            return await Db.Projetos.AsNoTracking()
                .Where(p => p.DataConclusao != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Projeto>> ObterProjetosComTarefasPorPrioridade(string prioridade)
        {
            return await Db.Projetos.AsNoTracking()
                .Where(p => p.Tarefas.Any(t => t.Prioridade == prioridade))
                .Include(p => p.Tarefas)
                .ToListAsync();
        }


    }
}
