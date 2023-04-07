using System.ComponentModel.DataAnnotations;

namespace PetShopApiServise.Models.AccountModels
{
    public class LoginModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 4)]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
