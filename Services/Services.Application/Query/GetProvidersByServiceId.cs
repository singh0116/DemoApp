using MediatR;
using Services.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Application.Query
{
    public class GetProvidersByServiceId
    {
        public class Query : IRequest<List<string>>
        {
            public string ServiceId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<string>>
        {
            private readonly IServicesRepo servicesRepo;

            public Handler(IServicesRepo servicesRepo)
            {
                this.servicesRepo = servicesRepo;
            }

            public Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.servicesRepo.GetProvidersByServiceIdAsync(request.ServiceId);
            }
        }
    }
}
