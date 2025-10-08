using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Notificacoes;
using Gerenciamento.Business.Services;
using Gerenciamento.Data.Context;
using Gerenciamento.Data.Repository;

namespace Gerenciamento.API.Configurations
{
    public static class DependencyInectionConfig 
    {
        public static IServiceCollection ResolvendoDependencies(this IServiceCollection services)
        {
            //Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            //Business 
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
