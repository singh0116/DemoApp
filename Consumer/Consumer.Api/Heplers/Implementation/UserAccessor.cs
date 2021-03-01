using Consumer.Api.Heplers.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Consumer.Api.Heplers.Implementation
{
    public class UserAccessor : IUserAccessor
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            string userId = null;

            var stream = this.GetToken();
            if (stream != null)
            {
                var tokenValue = new JwtSecurityTokenHandler().ReadToken(stream) as JwtSecurityToken;
                userId = Convert.ToString(tokenValue.Payload.Where(x => x.Key == "nameid").Select(x => x.Value).SingleOrDefault());
            }

            return userId;
        }

        private string GetToken()
        {
            string token = null;
            string authHeader = this.httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                token = authHeader.Split(" ")[1];
            }

            return token;
        }
    }
}