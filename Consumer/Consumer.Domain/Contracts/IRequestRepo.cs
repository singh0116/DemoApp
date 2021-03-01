using Consumer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consumer.Domain.Contracts
{
    public interface IRequestRepo
    {
        Task<List<ServiceRequest>> GetAllRequestsForUserAsync(string userId);

        Task<ServiceRequest> GetRequestByIdAsync(string requestId);

        Task<string> CreateRequestAsync(string userId, string serviceId);

        Task<bool> UpdateRequestStatus(string requestId, string status);
    }
}
