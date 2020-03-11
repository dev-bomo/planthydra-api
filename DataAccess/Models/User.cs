using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace planthydra_api.DataAccess.Models
{
    class User : IdentityUser
    {
        public List<Device> Devices { get; set; }

        public List<PlantComment> Comments { get; set; }

        public User()
        {
            this.Devices = new List<Device>();
            this.Comments = new List<PlantComment>();
        }
    }
}