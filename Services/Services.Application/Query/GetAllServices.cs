using MediatR;
using Services.Domain.Contracts;
using Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Application.Query
{
    public class GetAllServices
    {
        public class Query : IRequest<List<Service>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Service>>
        {
            private readonly IServicesRepo servicesRepo;

            public Handler(IServicesRepo servicesRepo)
            {
                this.servicesRepo = servicesRepo;
            }

            public Task<List<Service>> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.servicesRepo.GetAllServicesAsync();
            }
        }
    }
}
