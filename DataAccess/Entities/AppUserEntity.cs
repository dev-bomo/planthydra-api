using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    /// <summary>
    /// This is the application user. It contains an Identity user that is used for auth.
    /// This structure also contains domain specific information.
    /// </summary>
    [Table("AppUser")]
    class AppUserEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IdentityUser User { get; set; }

        public List<DeviceEntity> Devices { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public AppUserEntity()
        {
            this.Devices = new List<DeviceEntity>();
            this.Comments = new List<CommentEntity>();
        }
    }
}