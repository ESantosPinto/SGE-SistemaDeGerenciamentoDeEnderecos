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

        public async Task<Usuario> GetUsuarioPorLoginAsync(string usuarioLogin)
        {
            if (string.IsNullOrWhiteSpace(usuarioLogin))
                throw new ArgumentException("O login do usuário não pode ser nulo ou vazio.", nameof(usuarioLogin));

            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioLogin == usuarioLogin);
            }
            catch (Exception ex)
            {               
                throw new ApplicationException("Erro ao obter o usuário pelo login.", ex);
            }
        }
    }
}
