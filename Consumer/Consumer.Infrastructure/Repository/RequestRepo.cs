using Consumer.Domain.Constants;
using Consumer.Domain.Contracts;
using Consumer.Domain.Entities;
using Consumer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Infrastructure.Repository
{
    public class RequestRepo : IRequestRepo
    {
        public Task<List<ServiceRequest>> GetAllRequestsForUserAsync(string userId)
        {
            return Task.FromResult(FakeServiceRequestData.Requests.Where(x => x.UserId == userId).ToList());
        }

        public Task<ServiceRequest> GetRequestByIdAsync(string requestId)
        {
            return Task.FromResult(FakeServiceRequestData.Requests.Where(x => x.RequestId == requestId).SingleOrDefault());
        }

        public Task<string> CreateRequestAsync(string userId, string serviceId)
        {
            var serviceRequest = new ServiceRequest
            {
                RequestId = Guid.NewGuid().ToString(),
                UserId = userId,
                ServiceId = serviceId,
                Status = RequestStatus.Pending
            };

            FakeServiceRequestData.Requests.Add(serviceRequest);

            return Task.FromResult(serviceRequest.RequestId);
        }

        public Task<bool> UpdateRequestStatus(string requestId, string status)
        {
            var result = false;
            var request = FakeServiceRequestData.Requests.Where(x => x.RequestId == requestId).SingleOrDefault();
            if (request != null)
            {
                request.Status = status;
                result = true;
            }
            return Task.FromResult(result);
        }
    }
}
