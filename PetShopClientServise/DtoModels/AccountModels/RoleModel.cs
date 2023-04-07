using System.ComponentModel.DataAnnotations;

namespace PetShopClientServise.DtoModels;

public class RoleModel
{
    [Required]
    public string? RoleName { get; set; }
}

