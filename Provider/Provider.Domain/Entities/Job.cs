using System;
using System.Collections.Generic;
using System.Text;

namespace Provider.Domain.Entities
{
    public class Job
    {
        public string RequestId { get; set; }

        public string ProviderUserId { get; set; }

        public string Status { get; set; }
    }
}
