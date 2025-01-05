using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Dominio.Entidades;

namespace SGE.Infra.Data.ConfiguracaoDeEntidades;

public class ConfiguracaoEndereco : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Cep)
            .IsRequired()
            .HasMaxLength(9)
            .IsUnicode(false);

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(e => e.Complemento)
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(e => e.Bairro)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Uf)
            .IsRequired()
            .HasMaxLength(2)
            .IsUnicode(false);

        builder.Property(e => e.Numero)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false);

        builder.Property(e => e.UsuarioId)
            .IsRequired();

        builder.HasOne(e => e.Usuario)
            .WithMany(u => u.Enderecos)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Enderecos");

        // Adicionando dados iniciais para endereço
        builder.HasData(
            new Endereco
            {
                Id = 1,
                Cep = "12345-678",
                Logradouro = "Rua Principal",
                Complemento = "Apto 101",
                Bairro = "Centro",
                Cidade = "Cidade Exemplo",
                Uf = "SP",
                Numero = "100",
                UsuarioId = 1
            },
            new Endereco
            {
                Id = 2,
                Cep = "98765-432",
                Logradouro = "Avenida Secundária",
                Complemento = "Casa 20",
                Bairro = "Bairro Exemplo",
                Cidade = "Cidade Exemplo",
                Uf = "RJ",
                Numero = "200",
                UsuarioId = 2
            }
        );
    }
}
