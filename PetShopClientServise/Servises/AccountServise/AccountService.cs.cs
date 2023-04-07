using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.Utils.HttpClientUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.AccountServise
{
    [PetShopExceptionFilter]
    public class AccountService : IAccountService
    {

        public async Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> Login(LoginModel loginModel)
        {
            await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/Login", loginModel);
            return GetUserModelForClient(loginModel.Username!).Result;
        }

        public static async Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> GetUserModelForClient(string username)
        {
            var res = await HttpClientInfo.HttpClientServises.GetAsync($"api/Account/GetUserInfoForClient/{username}");

            var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

            return (userModel!, res.StatusCode);
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

        public async Task<(ActionResult<IEnumerable<UserInfoModelForCilent>>, HttpStatusCode)> GetAllUsersInfoForClient()
        {
            var res = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/GetAllUsersInfoForClient");

            var usersModelList = await res.Content.ReadFromJsonAsync<IEnumerable<UserInfoModelForCilent>>();

            return (usersModelList!.ToList(), res.StatusCode);
        }

        public async Task<HttpStatusCode> CreateRole(RoleModel roleModel)
        {
            var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/CreateRole", roleModel);
            return res.StatusCode;
        }

        public async Task<HttpStatusCode> ManageRolesOnUser(ManageRolesOnUserModel manageRolesOnUserModel)
        {
            var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/ManageRolesOnUser", manageRolesOnUserModel);
            return res.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteUserById(string id)
        {
            var res = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Account/DeleteUserById/{id}");
            return res.StatusCode;
        }

        public async Task<bool> CheckIfAuthenticated()
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/CheckIfAuthenticated");
            var content = await response.Content.ReadAsStringAsync();
            return bool.Parse(content);
        }

        public async Task<(UserInfoModelForCilent, HttpStatusCode)> GetCurrentUser()
        {
            var res = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/GetCurrentUser");
            var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

            if(res.StatusCode == HttpStatusCode.OK)
            {
                return (userModel!, res.StatusCode);
            }
            else
            {
                return(null!, res.StatusCode);   
            }
        }

        public async Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> GetUserModelForClientById(string id)
        {
            var res = await HttpClientInfo.HttpClientServises.GetAsync($"api/Account/GetUserModelForClientById/{id}");

            var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

            if (res.StatusCode == HttpStatusCode.OK)
            {
                return (userModel!, res.StatusCode);
            }
            else
            {
                return(new UserInfoModelForCilent() { }!, res.StatusCode);
            }
        }

        public async Task<(ActionResult<List<IdentityRole>>, HttpStatusCode)> GetAutorizationLevels()
        {
            var res = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/GetAutorizationLevels"); 

           var rolesList = await res.Content.ReadFromJsonAsync<List<IdentityRole>>();    

            if(res.StatusCode == HttpStatusCode.OK)
            {
                return (rolesList!, HttpStatusCode.OK);  
            }
            else
            {
                return(new List<IdentityRole>() { }, res.StatusCode);
            }
        }
    }
}
