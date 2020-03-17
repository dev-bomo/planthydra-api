using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class User : IUser
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<IDevice> Devices { get; private set; }
        public IEnumerable<IComment> Comments { get; private set; }
        public IdentityUser IdentityUser { get; set; }

        public User(IdentityUser identityUser)
        {
            this.Id = identityUser.Id;
            this.IdentityUser = identityUser;
            this.Name = identityUser.UserName;
            this.Email = identityUser.Email;
            this.Devices = new List<IDevice>();
            this.Comments = new List<IComment>();
        }

        public User(IdentityUser identityUser, string name, string email)
        {
            this.Id = identityUser.Id;
            this.IdentityUser = identityUser;
            this.Name = name;
            this.Email = email;
            this.Devices = new List<IDevice>();
            this.Comments = new List<IComment>();
        }
    }
}