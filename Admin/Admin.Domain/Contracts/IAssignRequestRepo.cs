using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Contracts
{
    public interface IAssignRequestRepo
    {
        Task<List<string>> GetUnAssignedRequestsAsync();

        Task<bool> AddNewRequestForAssignmentAsync(string requestId);

        Task<bool> RequestAssignedAsync(string requestId);
    }
}
