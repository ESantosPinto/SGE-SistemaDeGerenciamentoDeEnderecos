using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Dominio.Entities;
using System.Collections.Generic;

namespace SGE.Infra.Data.ConfiguracaoDeEntidades
{
    public class ConfiguracaoUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(u => u.UsuarioLogin)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasMany(u => u.Enderecos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Usuarios");

            // Adicionando dados iniciais (seed data)
            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Elias Santos",
                    UsuarioLogin = "EliasS",
                    Senha = "123456",
                    Enderecos = new List<Endereco>()
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Nilton Santos",
                    UsuarioLogin = "NiltonP",
                    Senha = "654321",
                    Enderecos = new List<Endereco>()
                }
            );
        }
    }
}
