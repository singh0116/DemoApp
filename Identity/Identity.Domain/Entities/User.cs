﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Entities
{
    /// <summary>
    /// User Entity.
    /// </summary>
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }
    }
}
