using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain.Contracts;
using Services.Infrastructure.Repo;

namespace Services.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IServicesRepo, ServicesRepo>();
            return services;
        }
    }
}
