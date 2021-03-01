using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer.Domain.Entities
{
    public class ServiceRequest
    {
        public string RequestId { get; set; }

        public string UserId { get; set; }

        public string ServiceId { get; set; }

        public string Status { get; set; }
    }
}
