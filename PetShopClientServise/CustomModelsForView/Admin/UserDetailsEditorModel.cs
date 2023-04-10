using Microsoft.AspNet.Identity.EntityFramework;
using PetShopClientServise.DtoModels.AccountModels;

namespace PetShopClientServise.CustomModelsForView.Admin;

public class UserDetailsEditorModel
{
    public UserInfoModelForCilent ? UserModelForCilent { get; set; }
    public List<IdentityRole> ? RolesList { get; set; }

}
