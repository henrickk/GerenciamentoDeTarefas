using Gerenciamento.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciamento.Data.Mapping
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(t => t.Status)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(t => t.Prioridade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(t => t.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(t => t.DataConclusao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)   
                .HasForeignKey(t => t.ProjetoId);

            builder.HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId);
            
            builder.ToTable("Tarefas");
        }
    }
}
