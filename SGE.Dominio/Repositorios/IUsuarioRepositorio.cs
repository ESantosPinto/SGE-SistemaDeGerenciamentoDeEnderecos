using Catalogo.Domain.Entities;

namespace SGE.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Endereco> GetUsuarioPorLoginAsync(string usuarioLogin);
    }
}
