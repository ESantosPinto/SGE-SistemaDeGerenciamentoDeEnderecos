using Microsoft.EntityFrameworkCore;
using SGE.Dominio.Entidades;
using SGE.Dominio.Interfaces;
using SGE.Infra.Data.Contexto;

namespace SGE.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AtualizarUsuarioAsync(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentException("Erro ao encontrar usuário.", nameof(usuario));

                var usuariResultado = _context.Usuarios.Update(usuario);
                if (usuariResultado == null)
                {
                    throw new ApplicationException("Erro ao atualizar usuario");
                }

                return usuario;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao obter o usuário pelo login.", ex);
            }
        }
        public async Task<Usuario> BuscarUsuarioPorLoginAsync(string usuarioLogin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuarioLogin))
                    throw new ArgumentException("O login do usuário não pode ser nulo ou vazio.", nameof(usuarioLogin));

               var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioLogin == usuarioLogin);
                return usuario == null ? new Usuario() : usuario; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao obter o usuário pelo login.", ex);
            }
        }
        public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentException("As informações do usuário não pode ser nulas ou vazias.", nameof(usuario));

                await _context.Usuarios.AddAsync(usuario);
                var usuarioResultado = _context.SaveChangesAsync().Result;

                if (usuarioResultado == null)
                {
                    throw new ApplicationException("Erro ao adicionar usuario");
                }

                return usuario;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao cadatrar usuario.", ex);
            }
        }
        public async Task<Usuario> DeletarUsuarioAsync(Usuario usuario)
        {

            try
            {
                if (usuario == null)
                    throw new ArgumentException("As informações do usuário não pode ser nulas ou vazias.", nameof(usuario));

                _context.Usuarios.Remove(usuario);
                var usuarioResultado = _context.SaveChangesAsync().Result;

                if (usuarioResultado == null)
                {
                    throw new ApplicationException("Erro ao adicionar usuario");
                }

                return usuario;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao cadatrar usuario.", ex);
            }
        }

    }
}
