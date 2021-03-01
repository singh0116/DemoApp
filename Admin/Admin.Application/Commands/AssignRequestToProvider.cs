using Admin.Domain.Contracts;
using MassTransit;
using MediatR;
using MessageModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Application.Commands
{
    public class AssignRequestToProvider
    {
        public class Command : IRequest<bool>
        {
            public string RequestId { get; set; }
            public string ProviderUserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IAssignRequestRepo assignRequestRepo;
            private readonly IPublishEndpoint publishEndpoint;

            public Handler(IAssignRequestRepo assignRequestRepo, IPublishEndpoint publishEndpoint)
            {
                this.assignRequestRepo = assignRequestRepo;
                this.publishEndpoint = publishEndpoint;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await this.assignRequestRepo.RequestAssignedAsync(command.RequestId);

                if (result)
                {
                    var message = new NewJob
                    {
                        RequestId = command.RequestId,
                        ProviderUserId = command.ProviderUserId
                    };
                    await this.publishEndpoint.Publish(message);
                }

                return result;
            }
        }
    }
}
