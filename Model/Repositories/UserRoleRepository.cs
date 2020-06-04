using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Repositories
{
    class UserRoleRepository : BaseRepository<AppUserEntity>, IUserRoleRepository
    {
        public UserRoleRepository(Db context) : base(context)
        {
        }

        public IEnumerable<IdentityUserRole<string>> GetIdentityRolesForUser(string UserId)
        {
            return context.UserRoles.Where(r => r.UserId == UserId);
        }

        public string GetRoleName(string RoleId)
        {
            return context.Roles.Single(r => r.Id == RoleId).Name;
        }
    }
}