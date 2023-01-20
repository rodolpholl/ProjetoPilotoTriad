using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Utils.Extensions
{
    public class KeycloakAuthorizationPolicy
    {
        public string PolicyName { get; set; }
        public IList<KeycloakAuthorizationPolicyOptions> options { get; set; }
    }

    public class KeycloakAuthorizationPolicyOptions
    {
        public string Name { get; set; }

        /// <summary>
        /// As opçãoes podem ser 'read', 'write'
        /// </summary>
        public string[] AccessOptions { get; set; }
        public string RequiredRealmRoles { get; set; }
        public string RequiredResourceRoles { get; set; }
    }

    public static class KeycloakExtensions
    {
        public static IServiceCollection RegisterKeycloakAuthentication(this IServiceCollection service, ConfigureHostBuilder host, ConfigurationManager configuration)
        {
            host.ConfigureKeycloakConfigurationSource();

            service.AddKeycloakAuthentication(configuration);

            return service;
        }

        public static IServiceCollection RegisterKeycloakAuthorization(this IServiceCollection service, KeycloakAuthorizationPolicy[] policies, ConfigurationManager configuration)
        {
            if (policies.Any())
            {
                service.AddAuthorization(options =>
                {
                    foreach (var policy in policies)
                    {
                        options.AddPolicy(policy.PolicyName, builder =>
                        {
                            foreach (var option in policy.options)
                            {

                                var policyAcess = string.Concat(option.Name, string.Join(":", option.AccessOptions));

                                builder.RequireProtectedResource(option.Name, policyAcess)
                                       .RequireRealmRoles(option.RequiredRealmRoles)
                                       .RequireResourceRoles(option.RequiredResourceRoles);
                            }
                        });
                    }
                })
                .AddKeycloakAuthorization(configuration);
            }
            
            return service;
        }
    }
}
