using ProjetoPiloto.Cadastro.API.Modules.Cadastro.Endpoints.Query;
using ProjetoPiloto.Cadastro.Application;
using ProjetoPiloto.Cadastro.Infraestrutura.ModelMap;
using ProjetoPiloto.Cadastro.Infraestrutura;
using ProjetoPiloto.Utils.Extensions.Modules;
using System.Reflection;

namespace ProjetoPiloto.Cadastro.API.Modules
{
    public class CadastroModule : IModuleBase
    {
        public IServiceCollection RegisterModule(IServiceCollection services, ConfigurationManager configuration)
        {

            // Add services to the container.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Vault Config
            //builder.Configuration
            //       .AddEnvironmentVariables()
            //       .AddVault(null,builder.Configuration);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Add Application Services
            services.AddInfrastructureServices(configuration); //Need just one class from Infrastructure Assembly to pass. May be any.
            services.AddApplicationServices();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, Serilog.ILogger logger)
        {
            endpoints.MapListAuthors(logger);
            endpoints.MapGetAuthor(logger);

            return endpoints;
        }
    }
}
