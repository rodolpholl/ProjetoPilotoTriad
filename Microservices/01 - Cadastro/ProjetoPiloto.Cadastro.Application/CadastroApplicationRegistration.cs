using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoPiloto.Utils.Behaviors;
using System.Reflection;

namespace ProjetoPiloto.Cadastro.Application
{
    public static class CadastroApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandlerExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}