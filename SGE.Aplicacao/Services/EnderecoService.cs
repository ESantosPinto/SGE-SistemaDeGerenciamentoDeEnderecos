using AutoMapper;
using Newtonsoft.Json;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Dominio.Entidades;
using SGE.Dominio.Interfaces;

namespace SGE.Aplicacao.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepositorio _enderecoRepositorio;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;

    public EnderecoService(IEnderecoRepositorio enderecoRepositorio, IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
    {
        _enderecoRepositorio = enderecoRepositorio;
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EnderecoDTO>> BuscarEnderecosPorUsuarioAsync(string login)
    {
        try
        {
            var usuario = await _usuarioRepositorio.BuscarUsuarioPorLoginAsync(login);
            if (usuario != null)
            {
                var enderecoEntities = await _enderecoRepositorio.BuscarEnderecosPorIdUsuarioAsync(usuario.Id);

                var enderecosDTO = _mapper.Map<IEnumerable<EnderecoDTO>>(enderecoEntities);
                if (enderecosDTO == null)
                {
                    throw new ApplicationException("Erro ao mapear os endereços.");
                }

                return enderecosDTO;
            }
            else
            {

                throw new Exception("Não encontrado informações do usuario");
            }
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

    public async Task<EnderecoDTO> BuscarEnderecoPorIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));

        try
        {
            var enderecoEntity = await _enderecoRepositorio.BuscarEnderecoPorIdAsync(id);

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

    public async Task<EnderecoDTO> AdicionarEnderecoAsync(EnderecoDTO endereco)
    {
       
        try
        {
            var usuario = await _usuarioRepositorio.BuscarUsuarioPorLoginAsync(endereco.UsuarioLogin);

            if (endereco== null || endereco.UsuarioLogin == null)
            {
                throw new ArgumentNullException(nameof(endereco));
            }

            endereco.UsuarioId = usuario.Id;

            var enderecoResultado = await _enderecoRepositorio.AdicionarEnderecoAsync(_mapper.Map<Endereco>(endereco));
            return _mapper.Map<EnderecoDTO>(enderecoResultado);
        }
        catch (Exception ex)
        {

            throw new ApplicationException("Erro ao adicionar o endereço.", ex);
        }
    }

    public async Task AtualizaEnderecoAsync(EnderecoDTO enderecoDTO)
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

    public async Task RemoveEnderecoAsync(int id)
    {

        if (id <= 0) throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));

        try
        {
            var enderecoEntity = await _enderecoRepositorio.BuscarEnderecoPorIdAsync(id);
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

    public async Task<DadosViaCep> BuscarEnderecoPorCep(string cep)
    {
        HttpClient _httpClient = new HttpClient();

        try
        {
            // Monta a URL da API ViaCEP com o CEP fornecido
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            // Faz a requisição HTTP para a API
            var response = await _httpClient.GetStringAsync(url);

            // Verifica se a resposta não é erro ou JSON vazio
            if (response.Contains("erro"))
            {
                Console.WriteLine("CEP não encontrado ou inválido.");
                return null;
            }

            // Converte a resposta JSON para o objeto Endereco
            var endereco = JsonConvert.DeserializeObject<DadosViaCep>(response);

            return endereco;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar a API: {ex.Message}");
            return null;
        }
    }
}