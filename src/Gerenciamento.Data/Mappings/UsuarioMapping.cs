using Gerenciamento.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciamento.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
           
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
           
            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasIndex(u => u.Email).IsUnique();
         
            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasColumnType("varchar(200)");
           
            builder.HasMany(u => u.Projetos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId);
           
            builder.HasMany(u => u.Tarefas)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId);
           
            builder.ToTable("Usuarios");
        }
    }
}
