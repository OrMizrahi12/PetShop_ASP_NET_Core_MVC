using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetShopApiServise.Models.AccountModels;
using PetShopApiServise.Attributes.AccountAttributes;
using PetShopApiServise.Attributes.ExeptionAttributes;
using Microsoft.EntityFrameworkCore;

namespace PetShopApiServise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [PetShopExceptionFilter]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region Login, Register, Logout

        [PetShopExceptionFilter]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }

        [PetShopExceptionFilter]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Username };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user"); 
                return Ok(result);
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(string.Join(Environment.NewLine, errors));
        }

        [PetShopExceptionFilter]
        [HttpPost("Logout")]
        [IsAuthenticatedFilter]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging out: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

        #region Administrator actions

        [PetShopExceptionFilter]
        [Authorize(Roles = "Administrators")]
        [HttpPost("ManageRolesOnUser")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<IActionResult> ManageRolesOnUser([FromBody] ManageRolesOnUserModel manageRolesOnUserModel)
        {
            var user = await _userManager.FindByIdAsync(manageRolesOnUserModel.UserId!);
            var roleByName = await _roleManager.FindByNameAsync(manageRolesOnUserModel?.RoleName!);

            if (manageRolesOnUserModel!.AddTheRole)
            {
                await _userManager.AddToRoleAsync(user!, roleByName!.Name!);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user!, roleByName!.Name!);
            }

            return Ok(ModelState);
        }

        [PetShopExceptionFilter]
        [Authorize(Roles = "Administrators")]
        [HttpPost("CreateRole")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel roleModel)
        {
            var newRole = new IdentityRole { Name = roleModel.RoleName };
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                return Ok(new { message = $"Role '{roleModel.RoleName}' has been created successfully." });
            }

            return BadRequest(result.Errors);
        }

        [PetShopExceptionFilter]
        [Authorize(Roles = "Administrators")]
        [HttpGet("GetUsers")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            List<IdentityUser> users = await Task.Run(() => _userManager.Users.ToList());
            var user = await _userManager.FindByNameAsync("OrMizrahi");
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(users);
        }

        #endregion


        [PetShopExceptionFilter]
        [HttpGet("GetUserRoles{username}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserRolesAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user!);
            return Ok(roles);
        }

        [PetShopExceptionFilter]
        [HttpGet("GetUserByName{username}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<UserManager<IdentityUser>>> GetUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return Ok(user);
        }

        [PetShopExceptionFilter]
        [HttpGet("GetUserById/{id}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<UserManager<IdentityUser>>> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return Ok(user);
        }

        [PetShopExceptionFilter]
        [HttpGet("GetUserModelForClientById/{id}")]
        [IsAuthenticatedFilter]
        public async Task<ActionResult<UserInfoModelForCilent>> GetUserModelForClientById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            UserInfoModelForCilent userModel = new();
            userModel.Username = user!.UserName;
            userModel.Id = user.Id;

            var userRoles = _userManager.GetRolesAsync(user!);
            userModel.Roles = userRoles.Result.ToList();

            return Ok(userModel);
        }

        [PetShopExceptionFilter]
        [HttpGet("GetUserRolesById/{id}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<string>>> GetUserRolesById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(roles);
        }

        [PetShopExceptionFilter]
        [HttpGet("GetUserInfoForClient/{username}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<UserInfoModelForCilent>> GetUserInfoForClient(string username)
        {
            UserInfoModelForCilent userModel = new();

            var userInfo = await _userManager.FindByNameAsync(username);
            userModel.Username = userInfo!.UserName;
            userModel.Id = userInfo.Id;

            var userRoles = _userManager.GetRolesAsync(userInfo!);
            userModel.Roles = userRoles.Result.ToList();

            return Ok(userModel);
        }

        [PetShopExceptionFilter]
        [HttpGet("GetAllUsersInfoForClient")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserInfoModelForCilent>>> GetAllUsersInfoForClient()
        {
            List<UserInfoModelForCilent> usersForClient = new();
            List<IdentityUser> users = await Task.Run(() => _userManager.Users.ToList());

            foreach (var identityUser in users)
            {
                UserInfoModelForCilent userModel = new()
                {
                    Username = identityUser.UserName,
                    Id = identityUser.Id,
                    Roles = _userManager.GetRolesAsync(identityUser!).Result.ToList(),
                };

                usersForClient.Add(userModel);
            }

            return Ok(usersForClient);
        }

        [PetShopExceptionFilter]
        [Authorize(Roles = "Administrators")]
        [HttpDelete("DeleteUserById/{id}")]
        [IsAuthenticatedFilter]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user!);

            return Ok();
        }

        [PetShopExceptionFilter]
        [HttpGet("CheckIfAuthenticated")]
        public bool CheckIfAuthenticated()
        {
            return User.Identity!.IsAuthenticated;
        }

        [PetShopExceptionFilter]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserInfoModelForCilent>> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
            UserInfoModelForCilent userModel = new();

            if (user == null)
            {
                return Ok(userModel);
            }
            var userInfo = await _userManager.FindByNameAsync(user!.UserName!);

            userModel.Username = userInfo!.UserName;
            userModel.Id = userInfo.Id;

            var userRoles = _userManager.GetRolesAsync(userInfo!);
            userModel.Roles = userRoles.Result.ToList();
            
            return Ok(userModel);    
        }

        [PetShopExceptionFilter]
        [HttpGet("GetAutorizationLevels")]
        public async Task<ActionResult<List<IdentityRole>>> GetAutorizationLevels()
        {
            var authLevelsList = await _roleManager.Roles.ToListAsync(); 

            return Ok(authLevelsList);

        }
    }
}
