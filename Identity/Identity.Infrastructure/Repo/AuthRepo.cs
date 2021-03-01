using Identity.Domain.Contracts;
using Identity.Domain.Entities;
using Identity.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repo
{
    /// <summary>
    /// Auth Repository.
    /// </summary>
    public class AuthRepo : IAuthRepo
    {
        public Task<bool> ValidateUserIdAndPasswordAsync(string userId, string password)
        {
            return Task.FromResult(FakeUserData.UserCollection.Any(x => x.Email == userId && x.Password == password && x.IsActive));
        }
    }
}
