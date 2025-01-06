using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Aplicacao.Services;
using SGE.Dominio.Entidades;
using SGE.Dominio.Interfaces;
using SGE.Infra.Data.Repositorios;

public class EnderecosController : Controller
{
    private readonly IEnderecoService _enderecoService;
    private readonly IUsuarioService _usuarioService;
    public UsuarioDTO usuarioDTO;

    public EnderecosController(IEnderecoService enderecoService, IUsuarioService usuarioService)
    {
        _enderecoService = enderecoService;
        _usuarioService = usuarioService;
    }

    // GET: /Enderecos/   
    public async Task<IActionResult> Lista(UsuarioDTO usuario)
    {
        try
        {
            usuarioDTO = usuario;

            List<EnderecoDTO> enderecos = new List<EnderecoDTO>();

            foreach (var endereco in await _enderecoService.BuscarEnderecosPorUsuarioAsync(usuarioDTO.UsuarioLogin))
            {
                enderecos.Add(endereco);
            }

            if (enderecos == null || !enderecos.Any())
            {
                return View(new List<EnderecoDTO>());
            }

            return View(enderecos);
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
        }
    }

    // GET: /Enderecos/Create
    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Enderecos/Create
    [HttpPost("Create")]
    public async Task<IActionResult> Create(string usuarioLogin, EnderecoDTO enderecoDTO)
    {
        if (!ModelState.IsValid)
        {
            try
            {
                var endereco = await _enderecoService.AdicionarEnderecoAsync(enderecoDTO);

                if (enderecoDTO == null)
                {
                    throw new Exception("Erro ao adicionar o endereço");
                }              

                await _usuarioService.AdicionarEnderecoAsync(usuarioLogin, enderecoDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao adicionar o endereço: " + ex.Message);
            }
        }

        return View(enderecoDTO);
    }

    // GET: /Enderecos/Edit/{id}
    [HttpGet("Editar/{id}")]
    public async Task<IActionResult> Editar(int id)
    {
        var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (endereco == null)
        {
            return NotFound(); // Se não encontrar o endereço, retorna erro 404
        }
        return View(endereco); // Exibe o formulário para editar o endereço
    }

    // POST: /Enderecos/Edit/{id}
    [HttpPost("Editar/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, EnderecoDTO enderecoDTO)
    {
        if (id != enderecoDTO.Id)
        {
            return BadRequest("ID do endereço não corresponde.");
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _enderecoService.AtualizaEnderecoAsync(enderecoDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao atualizar o endereço: " + ex.Message);
            }
        }

        return View(enderecoDTO);
    }

    // POST: /Enderecos/Deletar/{id}
    [HttpPost("Deletar/{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "ID inválido." });
        }

        try
        {
            var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
            if (endereco == null)
            {
                return NotFound(new { message = "Endereço não encontrado." });
            }

            await _enderecoService.RemoveEnderecoAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno do servidor.", details = ex.Message });
        }
    }
}