#nullable disable
using PetShopApiServise.Models;


namespace PetShopApiServise.DtoModels;

public partial class Users
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Addresses> Addresses { get; } = new List<Addresses>();

    public virtual ICollection<Cart> Cart { get; } = new List<Cart>();

    public virtual ICollection<Comments> Comments { get; } = new List<Comments>();

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();

    public virtual ICollection<PetSales> PetSales { get; } = new List<PetSales>();

    public virtual Roles Role { get; set; }

    public virtual ICollection<WishList> WishList { get; } = new List<WishList>();
}