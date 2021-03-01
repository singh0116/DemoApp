using MediatR;
using Provider.Domain.Contracts;
using Provider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Provider.Application.Queries
{
    public class GetPendingJobsOfUser
    {
        public class Query : IRequest<List<Job>>
        {
            public string ProviderUserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Job>>
        {
            private readonly IJobRepo jobRepo;

            public Handler(IJobRepo jobRepo)
            {
                this.jobRepo = jobRepo;
            }

            public Task<List<Job>> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.jobRepo.GetPendingJobsOfProviderAsync(request.ProviderUserId);
            }
        }
    }
}
