using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;

public class EnderecosController : Controller
{
    private readonly IEnderecoService _enderecoService;
    private readonly IUsuarioService   _usuarioService;

    public EnderecosController(IEnderecoService enderecoService, IUsuarioService usuarioService ,ILogger<EnderecosController> logger)
    {
        _enderecoService = enderecoService;
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var enderecos = await _enderecoService.BuscaaEnderecoAsync();
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0) return BadRequest(new { message = "ID inválido." });

        var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (endereco == null)
        {
            return NotFound(new { message = "Endereço não encontrado." });
        }
        return View(endereco); 
    }

    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string login, EnderecoDTO enderecoDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
               var endereco = _enderecoService.AdicionarEnderecoAsync(enderecoDTO).Result;
               
                if (endereco == null)
                {
                    throw new Exception("Erro ao adicionar o endereço");
                }

              await  _usuarioService.AdicionarEnderecoAsync(login,endereco);
                return RedirectToAction(nameof(Index)); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao adicionar o endereço: " + ex.Message);
            }
        }

        return View(enderecoDTO);
    }
       
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EnderecoDTO enderecoDTO)
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

    
}
