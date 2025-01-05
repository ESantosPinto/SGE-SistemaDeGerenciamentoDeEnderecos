using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SGE.Dominio.Entities;

namespace SGE.Infra.Data.Contexto;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext)
            .Assembly);
    }
}