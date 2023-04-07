using System.ComponentModel.DataAnnotations;

namespace PetShopClientServise.DtoModels;

public class ManageRolesOnUserModel
{
    [Required]
    public string? UserId { get; set; }
    [Required]
    public string? RoleName { get; set; }
    [Required]
    public bool? AddTheRole{ get; set;}
}

