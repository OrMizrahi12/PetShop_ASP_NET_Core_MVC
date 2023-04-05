using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.Utils.HttpClientUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.AccountServise
{
    [PetShopExceptionFilter]
    public class AccountService : IAccountService
    {
        /*
            TODO, What the clientApiService need?

            1. Login, Register, Logout - that return: 'Task<IActionResult>'.
            2. GetUserModelForClient - that get username, and return the user nodel for client.
            3. GetAllUsersNodelForClient - that return: Task<ActionResult<IEnumerable<UserInfoModelForCilent>>>.
            4. Task<IActionResult> CreateRole(RoleModel roleModel) - for create new roles.
            5. Task<IActionResult> ManageRolesOnUser(ManageRolesOnUserModel manageRolesOnUserModel) - for the admin will be able to update roles for users.
            6. DeleteUserById(string id) and return Task<IActionResult> - for the admin will able to remove user.

        */


        public Task<HttpStatusCode> Register()
        {
            throw new NotImplementedException();
        }

        public async Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> Login(LoginModel loginModel)
        {
           await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/Login", loginModel);
           return GetUserModelForClient(loginModel.Username!).Result;            
        }
        
        public static async Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> GetUserModelForClient(string username)
        {
            var res = await HttpClientInfo.HttpClientServises.GetAsync($"api/Account/GetUserInfoForClient/{username}");

            var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

            return (userModel!,res.StatusCode);  
        }

        public async Task<HttpStatusCode> Register(RegisterModel registerModel)
        {
            var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/Register", registerModel);
            return res.StatusCode;
        }

        public async Task<HttpStatusCode> Logout()
        {
            var res = await HttpClientInfo.HttpClientServises.PostAsync("api/Account/Logout", null);
            return res.StatusCode;
        }
    }
}
