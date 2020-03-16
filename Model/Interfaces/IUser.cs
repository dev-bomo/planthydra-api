using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace planthydra_api.Model.Interfaces
{
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }

        IdentityUser IdentityUser { get; set; }

        IEnumerable<IDevice> Devices { get; }

        IEnumerable<IComment> Comments { get; }
    }
}