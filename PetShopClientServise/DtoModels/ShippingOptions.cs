#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class ShippingOptions
{
    public int ShippingOptionId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string EstimatedDeliveryTime { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();
}