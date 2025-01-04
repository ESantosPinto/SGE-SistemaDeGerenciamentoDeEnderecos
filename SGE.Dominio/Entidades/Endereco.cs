namespace SGE.Dominio.Entities;

public class Endereco : Identity
{
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Uf { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
