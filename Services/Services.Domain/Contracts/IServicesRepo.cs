using Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Contracts
{
    public interface IServicesRepo
    {
        Task<List<Service>> GetAllServicesAsync();

        Task<Service> GetServiceByIdAsync(string serviceId);

        Task<List<string>> GetProvidersByServiceIdAsync(string serviceId);
    }
}
