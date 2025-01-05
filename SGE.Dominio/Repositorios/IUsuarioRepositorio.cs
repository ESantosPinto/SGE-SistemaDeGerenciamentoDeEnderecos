
using SGE.Dominio.Entidades;

namespace SGE.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> CriarUsuarioAsync(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorLoginAsync(string usuarioLogin);
        Task<Usuario> AtualizarUsuarioAsync(Usuario usuario);
        Task<Usuario> DeletarUsuarioAsync(Usuario usuario);
    }
}
