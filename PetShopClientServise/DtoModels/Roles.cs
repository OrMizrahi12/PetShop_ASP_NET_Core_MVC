#nullable disable
using PetShopApiServise.DtoModels;


namespace PetShopApiServise.Models;

public partial class Roles
{
    public int RoleId { get; set; }

    public string RoleName { get; set; }

    public virtual ICollection<Users> Users { get; } = new List<Users>();
}