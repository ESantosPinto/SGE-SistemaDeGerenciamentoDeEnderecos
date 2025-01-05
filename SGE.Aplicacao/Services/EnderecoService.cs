using AutoMapper;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Dominio.Entidades;
using SGE.Dominio.Interfaces;

namespace SGE.Aplicacao.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepositorio _enderecoRepositorio;
    private readonly IMapper _mapper;  

    public EnderecoService(IEnderecoRepositorio enderecoRepositorio, IMapper mapper)
    {
        _enderecoRepositorio = enderecoRepositorio;
        _mapper = mapper;       
    }


    public async Task<IEnumerable<EnderecoDTO>> GetEnderecos()
    {
        try
        {
            var enderecoEntities = await _enderecoRepositorio.GetEnderecosAsync();
            var enderecosDTO = _mapper.Map<IEnumerable<EnderecoDTO>>(enderecoEntities);

            if (enderecosDTO == null)
            {
                throw new ApplicationException("Erro ao mapear os endereços.");
            }

            return enderecosDTO;
        }
        catch (HttpRequestException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao obter endereços.", ex);
        }
    }


    public async Task<EnderecoDTO> GetPorId(int id)
    {
        if (id <= 0) throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));

        try
        {
            var enderecoEntity = await _enderecoRepositorio.GetEnderecoPorIdAsync(id);

            if (enderecoEntity == null)
            {
                throw new KeyNotFoundException("Endereço não encontrado.");
            }
            return _mapper.Map<EnderecoDTO>(enderecoEntity);
        }
        catch (Exception ex)
        {                
            throw new ApplicationException("Erro ao obter o endereço.", ex);
        }
    }

    public async Task Add(EnderecoDTO enderecoDTO)
    {
        if (enderecoDTO == null) throw new ArgumentNullException(nameof(enderecoDTO));

        try
        {
            var enderecoEntity = _mapper.Map<Endereco>(enderecoDTO);
            await _enderecoRepositorio.AddEnderecoAsync(enderecoEntity);
        }
        catch (Exception ex)
        {   
            
            throw new ApplicationException("Erro ao adicionar o endereço.", ex);
        }
    }

    public async Task Atualiza(EnderecoDTO enderecoDTO)
    {
        if (enderecoDTO == null) throw new ArgumentNullException(nameof(enderecoDTO));

        try
        {
            var enderecoEntity = _mapper.Map<Endereco>(enderecoDTO);
            await _enderecoRepositorio.AtualizarEnderecoAsync(enderecoEntity);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao atualizar o endereço.", ex);
        }
    }

    public async Task Remove(int id)
    {
        if (id <= 0) throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));

        try
        {
            var enderecoEntity = await _enderecoRepositorio.GetEnderecoPorIdAsync(id);
            if (enderecoEntity == null)
            {
                throw new KeyNotFoundException("Endereço não encontrado.");
            }
            await _enderecoRepositorio.RemoverEnderecoAsync(enderecoEntity);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao remover o endereço.", ex);
        }
    }
}
