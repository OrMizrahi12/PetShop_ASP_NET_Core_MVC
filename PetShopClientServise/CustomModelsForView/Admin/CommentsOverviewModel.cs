using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;

namespace PetShopClientServise.CustomModelsForView.Admin;

public class CommentsOverviewModel
{
    public List<Comments>? Comments { get; set; }
    public List<Animals>? Animals { get; set; }
    public List<UserInfoModelForCilent>? Users { get; set; }
}
