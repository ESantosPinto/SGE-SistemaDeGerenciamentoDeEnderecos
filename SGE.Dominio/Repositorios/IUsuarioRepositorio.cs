using Catalogo.Domain.Entities;
using SGE.Dominio.Entities;

namespace SGE.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetUsuarioPorLoginAsync(string usuarioLogin);
    }
}
