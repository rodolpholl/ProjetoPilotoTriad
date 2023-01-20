using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace ProjetoPiloto.Utils.Extensions.Modules
{
    public static class ModuleExtensions
    {
        //Listar módulos para seren adicionados no container DI
        static readonly List<IModuleBase> registeredModules = new List<IModuleBase>();

        public static IServiceCollection RegisterModules(this IServiceCollection services, Assembly currentAssemby, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            var modules = DiscoverModules(currentAssemby);
            foreach (var module in modules)
            {
                module.RegisterModule(services, configuration);
                registeredModules.Add(module);
            }
            return services;
        }

        public static WebApplication MapEndpoints(this WebApplication app, ILogger logger)
        {
            foreach (var module in registeredModules)
            {
                module.MapEndpoints(app, logger);
            }
            return app;
        }

        private static IEnumerable<IModuleBase> DiscoverModules(Assembly currentAssembly)
        {
            var result = currentAssembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModuleBase)))
                .Select(Activator.CreateInstance)
                .Cast<IModuleBase>();

            return result;
        }
    }
}
