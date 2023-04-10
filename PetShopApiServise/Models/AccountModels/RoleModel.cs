using System.ComponentModel.DataAnnotations;

namespace PetShopApiServise.Models.AccountModels;

public class RoleModel
{

    [Required]
    public string? RoleName { get; set; }
}
