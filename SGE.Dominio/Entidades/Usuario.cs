using SGE.Dominio.Entidades;

namespace SGE.Dominio.Entities;

public class Usuario : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string UsuarioLogin { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;   

}
