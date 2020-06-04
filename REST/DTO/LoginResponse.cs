using System.ComponentModel.DataAnnotations;

namespace planthydra_api.REST.DTO
{
#pragma warning disable CS8618 // dtos + they have a required annotation
    /// <summary>
    /// The response object for logging in or registering
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// JWT token used with every request. Has an expiration
        /// </summary>
        /// <value></value>
        [Required]
        public string JWTToken { get; set; }
        /// <summary>
        /// Refresh token used to get another JWT token when it expires
        /// </summary>
        /// <value></value>
        public string? RefreshToken { get; set; }
    }
}