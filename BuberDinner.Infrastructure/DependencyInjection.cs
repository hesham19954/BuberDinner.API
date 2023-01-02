using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IJWTGenerator, JWTGenerator>();
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
            return services;
        }
    }
}
