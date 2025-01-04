using AutoMapper;
using Catalogo.Domain.Entities;
using SGE.Aplicacao.DTOs;
using SGE.Dominio.Entities;

namespace Catalogo.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {        
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
    }
}
