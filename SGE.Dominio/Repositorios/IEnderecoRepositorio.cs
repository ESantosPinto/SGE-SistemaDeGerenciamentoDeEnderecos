using Catalogo.Domain.Entities;

namespace SGE.Dominio.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<IEnumerable<Endereco>> GetEnderecosAsync();
        Task<Endereco> GetEnderecoPorIdAsync(int id);
        Task<Endereco> AddEnderecoAsync(Endereco endereco);
        Task<Endereco> AtualizarEnderecoAsync(Endereco endereco);
        Task<Endereco> RemoverEnderecoAsync(Endereco endereco);
    }
}
