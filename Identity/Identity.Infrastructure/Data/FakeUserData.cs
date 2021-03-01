using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Data
{
    public static class FakeUserData
    {
        public static List<User> UserCollection = new List<User>
        {
            new User
            {
                Id = "1f698c7a-68eb-4fa6-9003-ba5086a9a735",
                Email = "consumer1@nagp.com",
                FirstName = "Consumer",
                LastName = "Kumar",
                IsActive = true,
                Address = "Pathankot, Punjab",
                Password = "Password",
                Role = "Consumer"
            },
            new User
            {
                Id = "8c26aa0b-551e-414e-b50c-c38f537848c7",
                Email = "admin1@nagp.com",
                FirstName = "Admin",
                LastName = "Singh",
                IsActive = true,
                Password = "Password",
                Role = "Admin"
            },
            new User
            {
                Id = "7cd9dea1-9671-4388-8e5c-1e6083c19abb",
                Email = "provider1@nagp.com",
                FirstName = "Provider",
                LastName = "Sharma",
                IsActive = true,
                Address = "Pathankot, Punjab",
                Password = "Password",
                Role = "Provider"
            }
        };
    }
}
