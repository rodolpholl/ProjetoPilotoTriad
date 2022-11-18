using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoPiloto.Cadastro.Application.Contracts.Persistance;
using ProjetoPiloto.Cadastro.Infraestrutura.Repositories;
using ProjetoPiloto.Shared.Repository.ModelConfigBase;
using System.Reflection;

namespace ProjetoPiloto.Cadastro.Infraestrutura
{
    public static class CadastroInfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, Assembly infrastructureAssembly)
        {

            //Configuire Database Connection
            services.AddNHibernate(configuration, infrastructureAssembly);

            //Register Repositories
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            return services;
        }
    }
}