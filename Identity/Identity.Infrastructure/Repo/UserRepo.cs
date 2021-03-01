using System.Linq;
using System.Threading.Tasks;
using Identity.Domain.Contracts;
using Identity.Domain.Entities;
using Identity.Infrastructure.Data;

namespace Identity.Infrastructure.Repo
{
    public class UserRepo : IUserRepo
    {
        public Task<User> GetUserByEmailIdAsync(string email)
        {
            var user = FakeUserData.UserCollection.Where(x => x.Email == email && x.IsActive).SingleOrDefault();
            return Task.FromResult(user);
        }
    }
}
