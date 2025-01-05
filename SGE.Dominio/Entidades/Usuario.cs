using Catalogo.Domain.Entities;
using SGE.Dominio.Entidades;

namespace SGE.Dominio.Entities;

public class Usuario : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string UsuarioLogin { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    public Usuario()
    {
    }

    public Usuario(string usuarioLogin, string senha)
    {
        UsuarioLogin = usuarioLogin;
        Senha = senha;
    }

    public Usuario(string nome, string usuarioLogin, string senha)
    {
        ValidateDomain(nome, usuarioLogin, senha);
    }

    private void ValidateDomain(string nome, string usuarioLogin, string senha)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
           "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(string.IsNullOrEmpty(usuarioLogin),
            "Usuário inválido. O nome de usuário é obrigatório");

        DomainExceptionValidation.When(string.IsNullOrEmpty(senha),
           "Senha inválida. A senha de usuário é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3,
           "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(usuarioLogin.Length < 3,
           "O nome deve ter no mínimo 6 caracteres");

        DomainExceptionValidation.When(senha.Length < 6,
            "A senha deve ter no mínimo 6 caracteres");

        Nome = nome;
        UsuarioLogin = usuarioLogin;
        Senha = senha;
    }
}
