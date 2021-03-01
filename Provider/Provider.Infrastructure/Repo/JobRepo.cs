using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Provider.Domain.Constants;
using Provider.Domain.Contracts;
using Provider.Domain.Entities;
using Provider.Infrastructure.Data;

namespace Provider.Infrastructure.Repo
{
    public class JobRepo : IJobRepo
    {
        public Task<bool> AcceptOrRejectJobAsync(string requestId, bool isAccepted)
        {
            var result = false;
            var job = FakeJobsData.Jobs.Where(x => x.RequestId == requestId).SingleOrDefault();
            if (job != null)
            {
                job.Status = isAccepted ? JobStatus.Accepted : JobStatus.Rejected;
                result = true;
            }
            return Task.FromResult(result);
        }

        public Task<List<Job>> GetPendingJobsOfProviderAsync(string userId)
        {
            return Task.FromResult(FakeJobsData.Jobs.Where(x => x.ProviderUserId == userId && x.Status == JobStatus.Pending).ToList());
        }

        public Task<bool> AssignNewJobToProviderAsync(string requestId, string providerUserId)
        {
            var job = new Job
            {
                RequestId = requestId,
                ProviderUserId = providerUserId,
                Status = JobStatus.Pending
            };

            FakeJobsData.Jobs.Add(job);

            return Task.FromResult(true);
        }
    }
}
