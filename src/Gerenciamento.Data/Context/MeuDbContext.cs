using Gerenciamento.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gerenciamento.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetProperties()
                             .Where(p => p.ClrType == typeof(string))))
            {
                if (property.GetColumnType() == null)
                {
                    property.SetColumnType("varchar(100)");
                }
            }

            var dateOnlyConverter = new ValueConverter<DateOnly?, DateTime?>(
                v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : null,
                v => v.HasValue ? DateOnly.FromDateTime(v.Value) : null
            );

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.DataConclusao)
                .HasColumnType("date");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    var prop = entry.Properties.FirstOrDefault(p => p.Metadata.Name == "DataCriacao");
                    if (prop != null && prop.CurrentValue == null)
                    {
                        prop.CurrentValue = DateTime.Now;
                    }
                }

                foreach (var prop in entry.Properties)
                {
                    if ((prop.Metadata.ClrType == typeof(DateTime) || prop.Metadata.ClrType == typeof(DateTime?))
                        && prop.CurrentValue is DateTime dt)
                    {
                        if (dt < new DateTime(1753, 1, 1))
                            prop.CurrentValue = null;
                    }
                }

                // Mantém DataCadastro
                if (entry.Entity.GetType().GetProperty("DataCadastro") != null)
                {
                    if (entry.State == EntityState.Added)
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    if (entry.State == EntityState.Modified)
                        entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
