using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoPiloto.Utils.Extensions.CORS
{
    public static class CORSExtensions
    {
        private static CorsOptions _corsOptinos;
        public static IServiceCollection AddMicroserviceCORS ( this IServiceCollection services, CORSOptions[] options = null)
        {

            if (options != null)
            {
                foreach (var option in options)
                {

                    services.AddCors(_corsOptinos =>
                    {
                        _corsOptinos.AddPolicy(option.PolicyName, builder =>
                        {
                            if (option.AllowedOrigins.Any())
                            {
                                builder.WithOrigins(option.AllowedOrigins);
                            }

                            if (option.AllowedMethods.Any())
                            {
                                builder.WithOrigins(option.AllowedMethods);
                            }

                            if (option.AllowedHeaders.Any())
                            {
                                builder.WithOrigins(option.AllowedHeaders);
                            }
                        });
                    });

                    
                }
            }
            else
            {
                services.AddCors(_corsOptinos => {
                    _corsOptinos.AddPolicy("default", builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
                });
            }

            return services;
        }
    }
}
