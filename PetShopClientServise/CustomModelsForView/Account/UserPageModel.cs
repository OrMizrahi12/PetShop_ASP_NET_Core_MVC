using PetShopClientServise.DtoModels.AccountModels;
using System.Net;

namespace PetShopClientServise.CustomModelsForView.Account;

public class UserPageModel
{
    public UserInfoModelForCilent ? UserModelForClient { get; set; }    
    public HttpStatusCode ChangedStatus { get; set; }
}
