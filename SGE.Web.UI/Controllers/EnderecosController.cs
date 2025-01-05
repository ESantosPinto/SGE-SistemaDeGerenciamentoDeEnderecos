using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;

namespace SGE.Web.UI.Controllers;

public class EnderecosController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;

    public EnderecosController(IEnderecoService enderecoService, ILogger<EnderecosController> logger)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Index()
    {
        try
        {
            var enderecos = await _enderecoService.GetEnderecos();
            if (enderecos == null || !enderecos.Any())
            {
                return Ok(new { message = "Não há endereços disponíveis no momento." });
            }
            return Ok(enderecos);
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
        }
    }
}
