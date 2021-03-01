using Admin.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Application.Queries
{
    public class GetUnAssignedRequests
    {
        public class Query : IRequest<List<string>>
        {

        }

        public class Handler : IRequestHandler<Query, List<string>>
        {
            private readonly IAssignRequestRepo assignRequestRepo;

            public Handler(IAssignRequestRepo assignRequestRepo)
            {
                this.assignRequestRepo = assignRequestRepo;
            }

            public Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.assignRequestRepo.GetUnAssignedRequestsAsync();
            }
        }
    }
}
