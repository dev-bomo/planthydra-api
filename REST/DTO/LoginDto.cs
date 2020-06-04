using System.ComponentModel.DataAnnotations;

namespace planthydra_api.REST.DTO
{
#pragma warning disable CS8618 // dtos + they have a required annotation
    public class LoginDto
    {
        /// <summary>
        /// The name that will be visible in the app
        /// </summary>
        /// <value></value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The user email
        /// </summary>
        /// <value></value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        /// <value></value>
        [Required]
        public string Password { get; set; }
    }
}