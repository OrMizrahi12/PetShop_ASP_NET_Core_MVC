using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;


namespace PetShopClientServise.CustomModelsForView.Animal;

public class ShowAnimalByIdModel
{
    public IEnumerable<Comments>? Comments { get; set; }
    public Animals? AnimalById { get; set; }
    public IEnumerable<UserInfoModelForCilent>? UsersList { get; set; }
    public UserInfoModelForCilent? CurrentUser { get; set; }
}
