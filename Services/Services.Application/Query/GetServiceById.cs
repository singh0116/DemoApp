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
    public class GetServiceById
    {
        public class Query : IRequest<Service>
        {
            public string ServiceId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Service>
        {
            private readonly IServicesRepo servicesRepo;

            public Handler(IServicesRepo servicesRepo)
            {
                this.servicesRepo = servicesRepo;
            }

            public Task<Service> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.servicesRepo.GetServiceByIdAsync(request.ServiceId);
            }
        }
    }
}
