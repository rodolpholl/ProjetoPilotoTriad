using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjetoPiloto.Utils.Extensions.Modules
{
    public interface IModuleBase
    {
        IServiceCollection RegisterModule(IServiceCollection services, ConfigurationManager configuration);
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, ILogger logger);
    }
}
