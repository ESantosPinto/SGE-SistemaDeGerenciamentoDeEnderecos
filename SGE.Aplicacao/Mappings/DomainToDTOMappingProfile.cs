using AutoMapper;
using SGE.Aplicacao.DTOs;
using SGE.Dominio.Entidades;


namespace SGE.Aplicacao.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {        
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();
    }
}
