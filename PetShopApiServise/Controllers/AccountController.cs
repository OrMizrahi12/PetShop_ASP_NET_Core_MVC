using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApiServise.Models;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetShopApiServise.Data;
using Microsoft.AspNetCore.Authorization;
using PetShopApiServise.Models.AccountModels;

namespace PetShopApiServise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
      
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);

            if (result.Succeeded)
            {
                return Ok(ModelState);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }


        //[Authorize(Roles = "Administrators")]
        [HttpPost("ManageRolesOnUser")]
        public async Task<IActionResult> ManageRolesOnUser([FromBody] ManageRolesOnUserModel manageRolesOnUserModel)
        {
            var user = await _userManager.FindByNameAsync(manageRolesOnUserModel.Username!);
            var res = await _userManager.AddToRoleAsync(user!, manageRolesOnUserModel.Role!);

            return Ok(ModelState);
        }

       // [Authorize(Roles = "Administrators")]
        [HttpPost("CreateRole")]
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




        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Username };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(string.Join(Environment.NewLine, errors));
        }

        [HttpPost("Logout")]
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

        [Authorize(Roles = "Administrators")]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            List<IdentityUser> users = await Task.Run(() => _userManager.Users.ToList());

            // Get the role of the user
            var user = await _userManager.FindByNameAsync("OrMizrahi");
            var roles = await _userManager.GetRolesAsync(user!);

            return Ok(users);
        }

        [HttpGet("GetUserRoles{username}")]
        public async Task<IActionResult> GetUserRolesAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user!);
            return Ok(roles);
        }

        [HttpGet("GetUserByName{username}")]
        public async Task<IActionResult> GetUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return Ok(user);
        }
    }
}
