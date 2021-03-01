using Identity.Domain.Contracts;
using Identity.Infrastructure.Repo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthRepo, AuthRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            return services;
        }
    }
}
