namespace PetShopApiServise.Models.AccountModels
{
    public class ManageRolesOnUserModel
    {
        public string? UserId { get; set; }
        public string? RoleName { get; set; }

        public bool AddTheRole { get; set; }
    }
}
