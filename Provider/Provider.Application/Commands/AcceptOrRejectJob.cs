using MassTransit;
using MediatR;
using MessageModels;
using Provider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Provider.Application.Commands
{
    public class AcceptOrRejectJob
    {
        public class Command : IRequest<bool>
        {
            public string RequestId { get; set; }

            public bool IsAccepted { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IJobRepo jobRepo;
            private readonly IPublishEndpoint publishEndpoint;

            public Handler(IJobRepo jobRepo, IPublishEndpoint publishEndpoint)
            {
                this.jobRepo = jobRepo;
                this.publishEndpoint = publishEndpoint;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await this.jobRepo.AcceptOrRejectJobAsync(command.RequestId, command.IsAccepted);
                if (result)
                {
                    var message = new AcceptOrRejectRequest
                    {
                        RequestId = command.RequestId,
                        IsAccepted = command.IsAccepted
                    };
                    await this.publishEndpoint.Publish(message);
                }
                return result;
            }
        }
    }
}
