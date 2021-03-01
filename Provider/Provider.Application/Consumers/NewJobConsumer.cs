using MassTransit;
using MessageModels;
using Provider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Application.Consumers
{
    public class NewJobConsumer : IConsumer<NewJob>
    {
        private readonly IJobRepo jobRepo;

        public NewJobConsumer(IJobRepo jobRepo)
        {
            this.jobRepo = jobRepo;
        }

        public async Task Consume(ConsumeContext<NewJob> context)
        {
            await this.jobRepo.AssignNewJobToProviderAsync(context.Message.RequestId, context.Message.ProviderUserId);
        }
    }
}
