using SGE.Aplicacao.DTOs;

namespace SGE.Aplicacao.Interfaces;

public interface IEnderecoService
{
    Task<IEnumerable<EnderecoDTO>> GetEnderecos();
    Task<EnderecoDTO> GetPorId(int id);
    Task Add(EnderecoDTO enderecoDTO);
    Task Atualiza(EnderecoDTO enderecoDTO);
    Task Remove(int id);
}
