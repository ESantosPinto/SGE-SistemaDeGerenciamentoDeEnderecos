using Catalogo.Domain.Entities;
using SGE.Aplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacao.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoDTO>> GetEnderecos();
        Task<EnderecoDTO> GetPorId(int id);
        Task Add(EnderecoDTO enderecoDTO);
        Task Atualiza(EnderecoDTO enderecoDTO);
        Task Remove(int id);
    }
}
