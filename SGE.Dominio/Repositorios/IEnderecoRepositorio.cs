
using SGE.Dominio.Entidades;

namespace SGE.Dominio.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<IEnumerable<Endereco>> BuscarEnderecosAsync();
        Task<Endereco> BuscarEnderecoPorIdAsync(int id);
        Task<Endereco> AdicionarEnderecoAsync(Endereco endereco);
        Task<Endereco> AtualizarEnderecoAsync(Endereco endereco);
        Task<Endereco> RemoverEnderecoAsync(Endereco endereco);
    }
}
