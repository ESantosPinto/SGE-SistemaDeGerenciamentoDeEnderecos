using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SGE.Dominio.Interfaces;
using SGE.Infra.Data.Contexto;

namespace SGE.Infra.Data.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly AppDbContext _context;        

        public EnderecoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> GetEnderecosAsync()
        {
            try
            {
                return await _context.Enderecos.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)            {
                
                throw new ApplicationException("Erro ao obter endereços.", ex);
            }
        }

        public async Task<Endereco> GetEnderecoPorIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));

            try
            {
                var endereco = await _context.Enderecos.FindAsync(id);
                if (endereco == null)
                {
                    throw new KeyNotFoundException("Endereço não encontrado.");
                }
                return endereco;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao obter o endereço por ID.", ex);
            }
        }

        public async Task<Endereco> AddEnderecoAsync(Endereco endereco)
        {
            if (endereco == null) throw new ArgumentNullException(nameof(endereco));

            try
            {
                await _context.AddAsync(endereco);
                await _context.SaveChangesAsync();
                return endereco;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao adicionar o endereço.", ex);
            }
        }

        public async Task<Endereco> AtualizarEnderecoAsync(Endereco endereco)
        {
            if (endereco == null) throw new ArgumentNullException(nameof(endereco));

            try
            {
                _context.Update(endereco);
                await _context.SaveChangesAsync();
                return endereco;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao atualizar o endereço.", ex);
            }
        }

        public async Task<Endereco> RemoverEnderecoAsync(Endereco endereco)
        {
            if (endereco == null) throw new ArgumentNullException(nameof(endereco));

            try
            {
                _context.Remove(endereco);
                await _context.SaveChangesAsync();
                return endereco;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao remover o endereço.", ex);
            }
        }
    }
}
