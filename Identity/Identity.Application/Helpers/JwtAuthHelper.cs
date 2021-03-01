using Identity.Application.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Identity.Application.Helpers
{
    public class JwtAuthHelper : IJwtAuthHelper
    {
        private readonly JwtTokenConfig jwtTokenConfig;
        private readonly byte[] secret;

        public JwtAuthHelper(JwtTokenConfig jwtTokenConfig)
        {
            this.jwtTokenConfig = jwtTokenConfig;
            this.secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
        }

        public string GenerateToken(string userId, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("role", role),
            };

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: DateTime.Now.AddMinutes(jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            var accessToken = jwtSecurityTokenHandler.WriteToken(jwtToken);

            return accessToken;
        }
    }
}
