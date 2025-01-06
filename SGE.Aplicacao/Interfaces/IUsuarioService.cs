using SGE.Aplicacao.DTOs;

namespace SGE.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> BuscarUsuarioAsync(string usuarioLogin);
        Task AdicionarEnderecoAsync(string login, EnderecoDTO endereco);
        Task<UsuarioDTO> CriarUsuarioAsync(UsuarioDTO usuarioDTO); 

    }
}
