using Microsoft.Extensions.DependencyInjection;
using POCF1.Business.Interfaces;
using POCF1.Business.Notificacoes;
using POCF1.Business.Services;
using POCF1.Data.Context;
using POCF1.Data.Repository;

namespace POCF1.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();

            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IPilotoRepository, PilotoRepository>();

            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<IPilotoService, PilotoService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
