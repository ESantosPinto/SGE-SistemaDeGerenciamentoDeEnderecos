using SGE.Dominio.Entidades;

namespace SGE.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetUsuarioPorLoginAsync(string usuarioLogin);
    }
}
