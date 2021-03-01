using Consumer.Domain.Constants;
using Consumer.Domain.Contracts;
using MassTransit;
using MessageModels;
using System.Threading.Tasks;

namespace Consumer.Application.Consumers
{
    public class RequestStatusUpdatedConsumer : IConsumer<AcceptOrRejectRequest>
    {
        private readonly IRequestRepo repo;

        public RequestStatusUpdatedConsumer(IRequestRepo repo)
        {
            this.repo = repo;
        }

        public async Task Consume(ConsumeContext<AcceptOrRejectRequest> context)
        {
            await this.repo.UpdateRequestStatus(
                context.Message.RequestId,
                context.Message.IsAccepted ? RequestStatus.Accepted : RequestStatus.Rejected);
        }
    }
}
