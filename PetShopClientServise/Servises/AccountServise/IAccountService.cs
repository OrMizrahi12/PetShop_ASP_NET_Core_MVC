using Microsoft.AspNet.Identity.EntityFramework;
using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;
using PetShopClientServise.Utils.Responses;
using System.Net;

namespace PetShopClientServise.Servises.AccountServise;

public interface IAccountService
{
    public Task<bool> CheckIfAuthenticated();
    public Task<HttpStatusCode> CreateRole(RoleModel roleModel);
    public Task<HttpStatusCode> DeleteUserById(string id);
    public Task<ClientResponse<IEnumerable<UserInfoModelForCilent>>> GetAllUsersInfoForClient();
    public Task<ClientResponse<UserInfoModelForCilent>> GetCurrentUser();
    public Task<ClientResponse<UserInfoModelForCilent>> Login(LoginModel loginModel);
    public Task<HttpStatusCode> Logout();
    public Task<HttpStatusCode> ManageRolesOnUser(ManageRolesOnUserModel manageRolesOnUserModel);
    public Task<HttpStatusCode> Register(RegisterModel registerModel);
    public Task<ClientResponse<UserInfoModelForCilent>> GetUserModelForClientById(string id);
    public Task<ClientResponse<IEnumerable<IdentityRole>>> GetAutorizationLevels();

    public Task<HttpStatusCode> ChangeUsername(ChangeUsernameModel changeUsernameModel);
    public Task<HttpStatusCode> ChangePassword(ChangePasswordModel changePasswordModel);

    
}
