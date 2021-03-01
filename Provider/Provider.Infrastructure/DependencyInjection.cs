using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Provider.Domain.Contracts;
using Provider.Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IJobRepo, JobRepo>();
            return services;
        }
    }
}
