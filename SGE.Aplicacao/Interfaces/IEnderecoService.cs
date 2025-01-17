﻿using SGE.Aplicacao.DTOs;
using SGE.Dominio.Entidades;

namespace SGE.Aplicacao.Interfaces;

public interface IEnderecoService
{
    Task<IEnumerable<EnderecoDTO>> BuscarEnderecosPorUsuarioAsync(string login);
    Task<EnderecoDTO> BuscarEnderecoPorIdAsync(int id);
    Task<EnderecoDTO> AdicionarEnderecoAsync(EnderecoDTO enderecoDTO);
    Task AtualizaEnderecoAsync(EnderecoDTO enderecoDTO);
    Task RemoveEnderecoAsync(int id);
    Task<DadosViaCep> BuscarEnderecoPorCep(string cep);
}