using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Domain.Contracts;
using Services.Domain.Entities;
using Services.Infrastructure.Data;

namespace Services.Infrastructure.Repo
{
    public class ServicesRepo : IServicesRepo
    {
        public Task<List<Service>> GetAllServicesAsync()
        {
            return Task.FromResult(FakeServicesData.Services);
        }

        public Task<Service> GetServiceByIdAsync(string serviceId)
        {
            return Task.FromResult(FakeServicesData.Services.Where(x => x.ServiceId == serviceId).SingleOrDefault());
        }

        public Task<List<string>> GetProvidersByServiceIdAsync(string serviceId)
        {
            return Task.FromResult(FakeServicesData.ProviderServices.Where(x => x.ServiceId == serviceId).Select(x => x.ProviderUserId).ToList());
        }
    }
}
