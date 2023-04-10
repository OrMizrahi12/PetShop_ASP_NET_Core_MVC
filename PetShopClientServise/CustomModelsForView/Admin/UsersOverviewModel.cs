using Microsoft.AspNet.Identity.EntityFramework;
using PetShopClientServise.DtoModels.AccountModels;

namespace PetShopClientServise.CustomModelsForView.Admin;

public class UsersOverviewModel
{
    public List<UserInfoModelForCilent> ? UserInfoModelForCilentsList { get ; set; }

    public List<IdentityRole> ? RolesList { get; set; }
}
