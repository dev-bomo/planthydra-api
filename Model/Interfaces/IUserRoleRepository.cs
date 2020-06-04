using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using planthydra_api.DataAccess.Entities;

namespace planthydra_api.Model.Interfaces
{
    public interface IUserRoleRepository
    {
        IEnumerable<IdentityUserRole<string>> GetIdentityRolesForUser(string UserId);
        string GetRoleName(string RoleId);
    }
}