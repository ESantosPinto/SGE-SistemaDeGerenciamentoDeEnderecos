﻿using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;

public class EnderecosController : Controller
{
    private readonly IEnderecoService _enderecoService;

    public EnderecosController(IEnderecoService enderecoService, ILogger<EnderecosController> logger)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var enderecos = await _enderecoService.GetEnderecos();
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

        var endereco = await _enderecoService.GetPorId(id);
        if (endereco == null)
        {
            return NotFound(new { message = "Endereço não encontrado." });
        }
        return View(endereco); 
    }
}
