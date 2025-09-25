using Gerenciamento.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciamento.Data.Mapping
{
    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            
            builder.Property(p => p.DataInicio)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.Property(p => p.DataFim)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.Property(p => p.DataConclusao)
                .IsRequired(false)
                .HasColumnType("datetime");
            
            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Projetos)
                .HasForeignKey(p => p.UsuarioId);
            
            builder.HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey(t => t.ProjetoId);
            
            builder.ToTable("Projetos");
        }
    }
}
