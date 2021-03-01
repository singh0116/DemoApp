using Identity.Application.Constants;
using Identity.Application.Helpers;
using Identity.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Commands
{
    /// <summary>
    /// Login Command and Handler.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Login Command.
        /// </summary>
        public class Command : IRequest<ServiceResultDto<string>>
        {
            /// <summary>
            /// Gets or sets User Id.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets Password.
            /// </summary>
            [Required]
            public string Password { get; set; }
        }

        /// <summary>
        /// Login Command Handler.
        /// </summary>
        public class Handler : IRequestHandler<Command, ServiceResultDto<string>>
        {
            private readonly IAuthRepo authRepo;
            private readonly IUserRepo userRepo;
            private readonly IJwtAuthHelper jwtAuthHelper;

            public Handler(IAuthRepo authRepo, IUserRepo userRepo, IJwtAuthHelper jwtAuthHelper)
            {
                this.authRepo = authRepo;
                this.userRepo = userRepo;
                this.jwtAuthHelper = jwtAuthHelper;
            }

            public async Task<ServiceResultDto<string>> Handle(Command command, CancellationToken cancellationToken)
            {
                var response = new ServiceResultDto<string>();

                var isValidUser = await this.authRepo.ValidateUserIdAndPasswordAsync(command.Email, command.Password);
                if (isValidUser)
                {
                    response.IsSuccess = true;

                    var user = await this.userRepo.GetUserByEmailIdAsync(command.Email);
                    response.Data = this.jwtAuthHelper.GenerateToken(user.Id, user.Email, user.Role);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Error = Messages.InvalidCredentials;
                }

                return response;
            }
        }
    }
}
