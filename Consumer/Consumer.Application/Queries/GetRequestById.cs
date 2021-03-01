using Consumer.Domain.Contracts;
using Consumer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Application.Queries
{
    public class GetRequestById
    {
        public class Query : IRequest<ServiceRequest>
        {
            public string RequestId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceRequest>
        {
            private readonly IRequestRepo repo;

            public Handler(IRequestRepo repo)
            {
                this.repo = repo;
            }

            public Task<ServiceRequest> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.repo.GetRequestByIdAsync(request.RequestId);
            }
        }
    }
}
