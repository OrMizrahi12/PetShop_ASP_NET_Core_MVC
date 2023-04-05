using System.ComponentModel.DataAnnotations;

namespace PetShopClientServise.DtoModels;

public class LoginModel
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}
