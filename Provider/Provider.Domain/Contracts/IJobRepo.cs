using Provider.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Provider.Domain.Contracts
{
    public interface IJobRepo
    {
        Task<bool> AcceptOrRejectJobAsync(string requestId, bool isAccepted);

        Task<List<Job>> GetPendingJobsOfProviderAsync(string userId);

        Task<bool> AssignNewJobToProviderAsync(string requestId, string providerUserId);
    }
}
