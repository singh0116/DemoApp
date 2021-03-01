using Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Identity.Domain.Contracts
{
    public interface IUserRepo
    {
        Task<User> GetUserByEmailIdAsync(string email);
    }
}
