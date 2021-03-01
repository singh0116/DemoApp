using Admin.Domain.Contracts;
using MassTransit;
using MessageModels;
using System;
using System.Threading.Tasks;

namespace Admin.Application.Consumers
{
    public class NewRequestConsumer : IConsumer<NewRequest>
    {
        private readonly IAssignRequestRepo assignRequestRepo;

        public NewRequestConsumer(IAssignRequestRepo assignRequestRepo)
        {
            this.assignRequestRepo = assignRequestRepo;
        }

        public async Task Consume(ConsumeContext<NewRequest> context)
        {
            await this.assignRequestRepo.AddNewRequestForAssignmentAsync(context.Message.RequestId);
        }
    }
}
