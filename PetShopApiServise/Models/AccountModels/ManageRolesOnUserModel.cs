using System.ComponentModel.DataAnnotations;

namespace PetShopApiServise.Models.AccountModels
{
    public class ManageRolesOnUserModel
    {
        [Required]
        public string? UserId { get; set; }
        
        [Required]
        public string? RoleName { get; set; }

        [Required]
        public bool AddTheRole { get; set; }
    }
}
