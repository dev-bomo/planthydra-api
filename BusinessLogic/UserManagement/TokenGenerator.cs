using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using planthydra_api.BusinessLogic.Common;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.BusinessLogic.UserManagement
{

    public interface ITokenGenerator
    {
        string GenerateTokensForNewUser(IUser user);
    }

    class TokenGenerator : ITokenGenerator
    {
        private readonly string JWTRol = "rol";
        private readonly string JWTId = "id";
        private readonly int JWTExpireDays = 30;
        private readonly IRepo _context;

        private readonly IHostEnvironment _environment;

        public TokenGenerator(IRepo context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public string GenerateTokensForNewUser(IUser user)
        {
            var identity = generateClaimsIdentity(user.Id, user.Name);
            IEnumerable<IdentityUserRole<string>> roles = _context.UserRole.GetIdentityRolesForUser(user.Id);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                identity.FindFirst(JWTRol),
                identity.FindFirst(JWTId)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, _context.UserRole.GetRoleName(role.RoleId)));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._environment.GetJwtKey()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(JWTExpireDays);

            var token = new JwtSecurityToken(
                this._environment.GetJwtIssuer(),
                this._environment.GetJwtIssuer(),
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private ClaimsIdentity generateClaimsIdentity(string id, string userName)
        {
            // TODO: set these as constants somewhere
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(JWTId, id),
                new Claim(JWTRol, "api_access")
            });
        }
    }
}