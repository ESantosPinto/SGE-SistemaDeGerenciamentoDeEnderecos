using SGE.Dominio.Entities;

namespace SGE.Dominio.Entidades;

public abstract class EntidadeBase : Identity
{
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public bool Ativo { get; set; } = true;
}
