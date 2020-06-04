using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using planthydra_api.BusinessLogic.Common;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.BusinessLogic.UserManagement
{
    public interface IUserAuthManager
    {
        Task<ActivityResult<IUser>> RegisterAndCreateUser(string userName, string email, string password);
    }
    public class UserAuthManager : IUserAuthManager
    {
        private UserManager<IdentityUser> _userManager;

        private SignInManager<IdentityUser> _signInManager;

        private IRepo _repo;

        public UserAuthManager(
            UserManager<IdentityUser> userManager,
            IRepo repo,
            SignInManager<IdentityUser> signInManager
        )
        {
            this._userManager = userManager;
            this._repo = repo;
            this._signInManager = signInManager;
        }

        public async Task<ActivityResult<IUser>> RegisterAndCreateUser(string userName, string email, string password)
        {
            IdentityUser usr = new IdentityUser() { UserName = userName, Email = email };
            IdentityResult result = await _userManager.CreateAsync(usr, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(usr, false);
                IUser user = new User(usr);
                _repo.User.Insert(user);
                _repo.Save();
                return new ActivityResult<IUser>(result.Succeeded, user, null);
            }
            else
            {
                return new ActivityResult<IUser>(result.Succeeded, null, result.Errors.Select(e => e.Description));
            }
        }
    }
}