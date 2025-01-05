using Catalogo.Application.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGE.Dominio.Interfaces;
using SGE.Infra.Data.Contexto;
using SGE.Infra.Data.Repositorios;

namespace SGE.Infra.IoC.Ioc;

public static class InjecaoDependenciaWeb
{
    public static IServiceCollection AddInfraIoCWeb(this IServiceCollection services,
         IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));    

        services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
