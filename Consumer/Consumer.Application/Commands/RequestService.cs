using Consumer.Domain.Contracts;
using MassTransit;
using MediatR;
using MessageModels;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Application.Commands
{
    public class RequestService
    {
        public class Command : IRequest<string>
        {
            public string ServiceId { get; set; }

            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IPublishEndpoint publishEndpoint;
            private readonly IRequestRepo consumerRepo;

            public Handler(IPublishEndpoint publishEndpoint, IRequestRepo consumerRepo)
            {
                this.publishEndpoint = publishEndpoint;
                this.consumerRepo = consumerRepo;
            }

            public async Task<string> Handle(Command command, CancellationToken cancellationToken)
            {
                // persist new request in db.
                var requestId = await this.consumerRepo.CreateRequestAsync(command.UserId, command.ServiceId);

                // publish new request message.
                var message = new NewRequest
                {
                    RequestId = requestId
                };
                await this.publishEndpoint.Publish(message);
                return requestId;
            }
        }
    }
}
