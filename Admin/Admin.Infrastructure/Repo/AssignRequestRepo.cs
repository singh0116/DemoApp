using Admin.Domain.Contracts;
using Admin.Domain.Entities;
using Admin.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Repo
{
    public class AssignRequestRepo : IAssignRequestRepo
    {
        public Task<List<string>> GetUnAssignedRequestsAsync()
        {
            return Task.FromResult(FakeAssignRequestData.AssignRequests.Where(x => !x.IsAssigned).Select(x => x.RequestId).ToList());
        }

        public Task<bool> AddNewRequestForAssignmentAsync(string requestId)
        {
            FakeAssignRequestData.AssignRequests.Add(new AssignRequest { RequestId = requestId });
            return Task.FromResult(true);
        }

        public Task<bool> RequestAssignedAsync(string requestId)
        {
            var result = false;
            var request = FakeAssignRequestData.AssignRequests.Where(x => x.RequestId == requestId).SingleOrDefault();
            if (request != null)
            {
                request.IsAssigned = true;
                result = true;
            }
            return Task.FromResult(result);
        }
    }
}
