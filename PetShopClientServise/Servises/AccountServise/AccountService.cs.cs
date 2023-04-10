using Microsoft.AspNet.Identity.EntityFramework;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Responses;
using System.Net;
using System.Net.Http.Json;

namespace PetShopClientServise.Servises.AccountServise;

[PetShopExceptionFilter]
public class AccountService : IAccountService
{
    [PetShopExceptionFilter]
    public async Task<ClientResponse<UserInfoModelForCilent>> Login(LoginModel loginModel)
    {
        await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/Login", loginModel);
        return GetUserModelForClient(loginModel.Username!).Result;
    }

    [PetShopExceptionFilter]
    public static async Task<ClientResponse<UserInfoModelForCilent>> GetUserModelForClient(string username)
    {
        var res = await HttpClientInfo.HttpClientServises.GetAsync($"api/Account/GetUserInfoForClient/{username}");

        var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

        return new ClientResponse<UserInfoModelForCilent> { Data = userModel, StatusCode = res.StatusCode };
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> Register(RegisterModel registerModel)
    {
        var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/Register", registerModel);
        return res.StatusCode;
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> Logout()
    {
        var res = await HttpClientInfo.HttpClientServises.PostAsync("api/Account/Logout", null);
        return res.StatusCode;
    }

    [PetShopExceptionFilter]
    public async Task<ClientResponse<IEnumerable<UserInfoModelForCilent>>> GetAllUsersInfoForClient()
    {
        var res = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/GetAllUsersInfoForClient");

        var usersModelList = await res.Content.ReadFromJsonAsync<IEnumerable<UserInfoModelForCilent>>();

        return new ClientResponse<IEnumerable<UserInfoModelForCilent>> { Data = usersModelList, StatusCode = res.StatusCode };
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> CreateRole(RoleModel roleModel)
    {
        var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/CreateRole", roleModel);
        return res.StatusCode;
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> ManageRolesOnUser(ManageRolesOnUserModel manageRolesOnUserModel)
    {
        var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/ManageRolesOnUser", manageRolesOnUserModel);
        return res.StatusCode;
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> DeleteUserById(string id)
    {
        var res = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Account/DeleteUserById/{id}");
        return res.StatusCode;
    }

    [PetShopExceptionFilter]
    public async Task<bool> CheckIfAuthenticated()
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/CheckIfAuthenticated");
        var content = await response.Content.ReadAsStringAsync();
        return bool.Parse(content);
    }

    [PetShopExceptionFilter]
    public async Task<ClientResponse<UserInfoModelForCilent>> GetCurrentUser()
    {
        var res = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/GetCurrentUser");
        var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

        if(res.StatusCode == HttpStatusCode.OK)
        {
            return new ClientResponse<UserInfoModelForCilent> { Data = userModel, StatusCode = res.StatusCode };
        }
        else
        {
            return new ClientResponse<UserInfoModelForCilent> { Data = new UserInfoModelForCilent() { }, StatusCode = res.StatusCode };   
        }
    }

    [PetShopExceptionFilter]
    public async Task<ClientResponse<UserInfoModelForCilent>> GetUserModelForClientById(string id)
    {
        var res = await HttpClientInfo.HttpClientServises.GetAsync($"api/Account/GetUserModelForClientById/{id}");

        var userModel = await res.Content.ReadFromJsonAsync<UserInfoModelForCilent>();

        if (res.StatusCode == HttpStatusCode.OK)
        {
            return new ClientResponse<UserInfoModelForCilent> { Data = userModel, StatusCode = res.StatusCode };
        }
        else
        {
            return new ClientResponse<UserInfoModelForCilent> { Data = new UserInfoModelForCilent { }, StatusCode = res.StatusCode };
        }
    }

    [PetShopExceptionFilter]
    public async Task<ClientResponse<IEnumerable<IdentityRole>>> GetAutorizationLevels()
    {
        var res = await HttpClientInfo.HttpClientServises.GetAsync("api/Account/GetAutorizationLevels"); 

       var rolesList = await res.Content.ReadFromJsonAsync<List<IdentityRole>>();    

        if(res.StatusCode == HttpStatusCode.OK)
        {
            return new ClientResponse<IEnumerable<IdentityRole>> { Data = rolesList, StatusCode = res.StatusCode };
        }
        else
        {
            return new ClientResponse<IEnumerable<IdentityRole>> { Data = new List<IdentityRole> { }, StatusCode = res.StatusCode };
        }
    }

    public async Task<HttpStatusCode> ChangeUsername(ChangeUsernameModel changeUsernameModel)
    {
        var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/ChangeUsername", changeUsernameModel);
        return res.StatusCode;
    }

    public async Task<HttpStatusCode> ChangePassword(ChangePasswordModel changePasswordModel)
    {
        var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Account/ChangePassword", changePasswordModel);
        return res.StatusCode;
    }
}
