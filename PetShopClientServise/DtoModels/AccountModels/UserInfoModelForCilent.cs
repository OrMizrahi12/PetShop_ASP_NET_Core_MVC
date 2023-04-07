using System.ComponentModel.DataAnnotations;

namespace PetShopClientServise.DtoModels.AccountModels;

public class UserInfoModelForCilent
{

    [Required]
    public string? Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public List<string>? Roles { get; set; }
}
