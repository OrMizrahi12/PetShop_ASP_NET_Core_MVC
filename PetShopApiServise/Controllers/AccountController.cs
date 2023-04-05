using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetShopApiServise.Models.AccountModels;
using PetShopApiServise.Attributes.AccountAttributes;
using PetShopApiServise.Attributes.ExeptionAttributes;

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

        [HttpPost("Login")]
        public async Task<ActionResult<UserManager<IdentityUser>>> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Username };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                SetDefaultRoleInUser(user.UserName!);
                return Ok(result);
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(string.Join(Environment.NewLine, errors));
        }

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

        [Authorize(Roles = "Administrators")]
        [HttpPost("ManageRolesOnUser")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<IActionResult> ManageRolesOnUser([FromBody] ManageRolesOnUserModel manageRolesOnUserModel)
        {
            var user = await _userManager.FindByNameAsync(manageRolesOnUserModel.Username!);
            await _userManager.AddToRoleAsync(user!, manageRolesOnUserModel.Role!);

            return Ok(ModelState);
        }

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



        [HttpGet("GetUserRoles{username}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserRolesAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user!);
            return Ok(roles);
        }

        [HttpGet("GetUserByName{username}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<UserManager<IdentityUser>>> GetUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return Ok(user);
        }

        [HttpGet("GetUserById/{id}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<UserManager<IdentityUser>>> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return Ok(user);
        }


        [HttpGet("GetUserRolesById/{id}")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<string>>> GetUserRolesById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(roles);
        }

        private async void SetDefaultRoleInUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            await _userManager.AddToRoleAsync(user!, "user");
        }

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
    }
}