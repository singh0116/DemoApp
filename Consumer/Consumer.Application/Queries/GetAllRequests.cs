using Consumer.Domain.Contracts;
using Consumer.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Application.Queries
{
    public class GetAllRequests
    {
        public class Query : IRequest<List<ServiceRequest>>
        {
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ServiceRequest>>
        {
            private readonly IRequestRepo repo;

            public Handler(IRequestRepo repo)
            {
                this.repo = repo;
            }

            public Task<List<ServiceRequest>> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.repo.GetAllRequestsForUserAsync(request.UserId);
            }
        }
    }
}
