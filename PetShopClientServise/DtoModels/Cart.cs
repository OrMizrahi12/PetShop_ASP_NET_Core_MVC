#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual PetProducts Product { get; set; }

    public virtual Users User { get; set; }
}