using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using planthydra_api.BusinessLogic.Common;
using planthydra_api.BusinessLogic.UserManagement;
using planthydra_api.Model.Interfaces;
using planthydra_api.REST.DTO;

namespace planthydra_api.REST
{

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private IUserAuthManager _userAuthManager;
        private ITokenGenerator _tokenGenerator;

        public AccountController(IUserAuthManager uam, ITokenGenerator tokenGenerator)
        {
            _userAuthManager = uam;
            _tokenGenerator = tokenGenerator;
        }

        /// <summary>
        /// Logs in the user based on an email and a password
        /// </summary>
        /// <param name="login">email + password</param>
        /// <returns>Bad request if the credentials are not correct or can't find user. OK otherwise</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDto login)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Login via facebook
        /// </summary>
        /// <param name="fbLoginToken">token emitted by fb oauth</param>
        /// <returns>Bad request if can't log in. Ok otherwise</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> FacebookLogin([FromBody] string fbLoginToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers a new user based on an email and password
        /// </summary>
        /// <param name="register">email + password</param>
        /// <returns>Bad request if validation errors or user exists. OKCreated otherwise</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Register([FromBody] LoginDto register)
        {
            ActivityResult<IUser> result =
                await _userAuthManager.RegisterAndCreateUser(register.Name, register.Email, register.Password);
            if (result.Success)
            {
                string jwtToken = this._tokenGenerator.GenerateTokensForNewUser(result.Payload);
                return Ok(new LoginResponse { JWTToken = jwtToken });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        /// <summary>
        /// Triggers the reset password flow by verifying the user and sending an email if exists
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>OK even if the user doesn't exist. We don't want to give away information</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ForgotPassword([FromBody] string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Resets the password
        /// </summary>
        /// <param name="resetPass">email + new password + reset code</param>
        /// <returns>OK if it was reset or nothing happened. 400 if the new password doesn't meet requirements</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto resetPass)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Emits a new jwt token for a given refresh token
        /// </summary>
        /// <param name="refreshToken">user refresh token</param>
        /// <returns>The new jwt token or a bad request if the token could not be emitted</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> RefreshJwtToken([FromBody] string refreshToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs out the currently logged in user
        /// </summary>
        /// <returns>OK if logout was successful. 400 otherwise</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LogOut()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the expo push token so the user can get push notifications
        /// </summary>
        /// <param name="expoPushToken">The token</param>
        /// <returns>Either OK if it was set or bad request if there was a problem</returns>
        [HttpOptions]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SetExpoPushToken([FromBody] string expoPushToken)
        {
            throw new NotImplementedException();
        }
    }
}