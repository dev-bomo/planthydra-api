using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace planthydra_api.DataAccess.Entities
{
    [Table("User")]
    public class UserEntity : IdentityUser
    {
    }
}