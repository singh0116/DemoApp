using Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Infrastructure.Data
{
    public static class FakeServicesData
    {
        public static List<Service> Services = new List<Service>
        {
            new Service
            {
                ServiceId = "75bca20d-af0a-4ea8-a12f-a7260e068415",
                Name = "Electricians",
                Description = "Electricians"
            },
            new Service
            {
                ServiceId = "5c48b1f6-018d-44b8-b58e-bcb2bb2dd216",
                Name = "Yoga Trainers",
                Description = "Yoga Trainers"
            },
            new Service
            {
                ServiceId = "c480d22c-bdc6-4e09-bfaf-8dec4ef0038d",
                Name = "Interior Designers",
                Description = "Interior Designers"
            }
        };

        public static List<ProviderService> ProviderServices = new List<ProviderService>
        {
            new ProviderService
            {
                ServiceId = "75bca20d-af0a-4ea8-a12f-a7260e068415",
                ProviderUserId = "7cd9dea1-9671-4388-8e5c-1e6083c19abb"
            },
            new ProviderService
            {
                ServiceId = "5c48b1f6-018d-44b8-b58e-bcb2bb2dd216",
                ProviderUserId = "7cd9dea1-9671-4388-8e5c-1e6083c19abb"
            },
            new ProviderService
            {
                ServiceId = "c480d22c-bdc6-4e09-bfaf-8dec4ef0038d",
                ProviderUserId = "7cd9dea1-9671-4388-8e5c-1e6083c19abb"
            }
        };
    }
}
