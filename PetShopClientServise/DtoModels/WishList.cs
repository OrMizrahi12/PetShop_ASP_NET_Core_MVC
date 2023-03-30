#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class WishList
{
    public int WishId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public virtual PetProducts Product { get; set; }

    public virtual Users User { get; set; }
}