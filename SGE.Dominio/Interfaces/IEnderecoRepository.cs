using SGE.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Dominio.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> GetEnderecosAsync();
        Task<Endereco> GetEnderecoPorCepAsync(string cep);
        Task<Endereco> AddEnderecoAsync(Endereco endereco);
        Task<Endereco> AtualizarEnderecoAsync(Endereco endereco);
        Task<Endereco> RemoverEnderecoAsync(Endereco endereco);
    }
}
