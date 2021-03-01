using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Domain.Entities
{
    public class AssignRequest
    {
        public string RequestId { get; set; }

        public bool IsAssigned { get; set; }
    }
}
