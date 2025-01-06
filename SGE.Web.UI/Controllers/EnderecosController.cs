using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Dominio.Entidades;
using System.Text;
using System.Text.RegularExpressions;

[Route("Enderecos")]
public class EnderecosController : Controller
{
    private readonly IEnderecoService _enderecoService;
    private readonly IUsuarioService _usuarioService;

    public EnderecosController(IEnderecoService enderecoService, IUsuarioService usuarioService)
    {
        _enderecoService = enderecoService;
        _usuarioService = usuarioService;
    }

    // GET: /Enderecos/
    [HttpGet]
    public async Task<IActionResult> Index(UsuarioDTO usuario)
    {
        try
        {
            var enderecos = await _enderecoService.BuscarEnderecosPorUsuarioAsync(usuario.UsuarioLogin);
            ViewData["Usuario"] = usuario;
            return View(enderecos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao carregar endereços: {ex.Message}");
        }
    }

    // GET: /Enderecos/Details/{id}
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
            if (endereco == null)
                return NotFound("Endereço não encontrado.");

            return View(endereco);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao carregar o endereço: {ex.Message}");
        }
    }

    // GET: /Enderecos/Create
    [HttpGet("Create")]
    public IActionResult Create(UsuarioDTO usuario)
    {
        // Substitua pela lógica correta para obter o usuário
        ViewData["Usuario"] = usuario;
        return View();
    }


    // POST: /Enderecos/Create
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EnderecoDTO endereco)
    {
        if (!ModelState.IsValid)
        {
            return View(endereco);
        }
           
        var usuarioLogin = endereco.UsuarioLogin;
        try
        {
            await _enderecoService.AdicionarEnderecoAsync(endereco);
            UsuarioDTO usuarioDTO =await _usuarioService.BuscarUsuarioAsync(endereco.UsuarioLogin);
            return View(Index(usuarioDTO));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao adicionar o endereço: {ex.Message}");
            return View(endereco);
        }
    }

    // GET: /Enderecos/Edit/{id}
    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (endereco == null)
            return NotFound();

        return View(endereco);
    }

    // POST: /Enderecos/Edit/{id}
    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EnderecoDTO enderecoDTO)
    {
        if (id != enderecoDTO.Id)
            return BadRequest("ID do endereço não corresponde.");

        if (!ModelState.IsValid)
            return View(enderecoDTO);

        try
        {
            await _enderecoService.AtualizaEnderecoAsync(enderecoDTO);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Erro ao atualizar o endereço: {ex.Message}");
            return View(enderecoDTO);
        }
    }

    // GET: /Enderecos/Delete/{id}
    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
        if (endereco == null)
            return NotFound();

        return View(endereco);
    }

    // POST: /Enderecos/Delete/{id}
    [HttpPost("Delete/{id}"), ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        try
        {
            await _enderecoService.RemoveEnderecoAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao excluir o endereço: {ex.Message}");
        }
    }

    // Método auxiliar para limpar CEP
    public static string LimparCep(string cep)
    {
        return string.IsNullOrWhiteSpace(cep) ? string.Empty : Regex.Replace(cep, @"\D", "");
    }

    [HttpGet("Buscar")]
    public async Task<IActionResult> Buscar(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
        {
            return BadRequest(new { message = "CEP inválido." });
        }

        try
        {
            var endereco = await _enderecoService.BuscarEnderecoPorCep(cep);
            if (endereco == null)
            {
                return NotFound(new { message = "Endereço não encontrado." });
            }

            return Json(new
            {
                logradouro = endereco.Logradouro,
                complemento = endereco.Complemento,
                bairro = endereco.Bairro,
                cidade = endereco.Cidade,
                uf = endereco.Uf
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao buscar o endereço.", details = ex.Message });
        }
    }

    [HttpGet("ExportarCSV")]
    public async Task<IActionResult> ExportarCSV(string usuarioLogin)
    {
        if (string.IsNullOrEmpty(usuarioLogin))
        {
            return BadRequest("O login do usuário não foi fornecido.");
        }

        try
        {
            // Recupera os endereços do usuário pelo login
            var enderecos = await _enderecoService.BuscarEnderecosPorUsuarioAsync(usuarioLogin);

            if (enderecos == null || !enderecos.Any())
            {
                return BadRequest("Não há endereços disponíveis para exportação.");
            }

            // Cria o conteúdo do CSV
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Id,Cep,Logradouro,Complemento,Bairro,Cidade,Uf,Numero");

            foreach (var endereco in enderecos)
            {
                csvContent.AppendLine(
                    $"{endereco.Id}," +
                    $"{endereco.Cep}," +
                    $"{endereco.Logradouro}," +
                    $"{endereco.Complemento}," +
                    $"{endereco.Bairro}," +
                    $"{endereco.Cidade}," +
                    $"{endereco.Uf}," +
                    $"{endereco.Numero}"
                );
            }

            // Retorna o CSV como um arquivo para download
            var bytes = Encoding.UTF8.GetBytes(csvContent.ToString());
            var fileName = $"enderecos_{usuarioLogin}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            return File(bytes, "text/csv", fileName);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao exportar os endereços.", details = ex.Message });
        }
    }



}
