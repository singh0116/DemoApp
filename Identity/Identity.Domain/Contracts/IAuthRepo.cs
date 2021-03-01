using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Contracts
{
    /// <summary>
    /// Auth Contract.
    /// </summary>
    public interface IAuthRepo
    {
        /// <summary>
        /// Validates User Id and Password.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="password">User Password.</param>
        /// <returns>true, if user id and password is validated successfully.</returns>
        Task<bool> ValidateUserIdAndPasswordAsync(string userId, string password);
    }
}
