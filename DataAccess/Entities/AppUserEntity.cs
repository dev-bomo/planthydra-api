using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace planthydra_api.DataAccess.Entities
{
    /// <summary>
    /// This is the application user. It contains an Identity user that is used for auth.
    /// This structure also contains domain specific information.
    /// </summary>
    [Table("AppUser")]
    class AppUserEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IdentityUser User { get; set; }

        public List<DeviceEntity> Devices { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public AppUserEntity(IdentityUser user)
        {
            this.User = user;
            this.Id = user.Id;
            this.Name = user.UserName;
            this.Email = user.Email;
            this.Devices = new List<DeviceEntity>();
            this.Comments = new List<CommentEntity>();
        }
    }
}