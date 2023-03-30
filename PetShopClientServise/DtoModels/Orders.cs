#nullable disable

namespace PetShopApiServise.DtoModels;

public partial class Orders
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? AddressId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal Total { get; set; }

    public int? DiscountId { get; set; }

    public int? ShippingOptionId { get; set; }

    public string Status { get; set; }

    public virtual Addresses Address { get; set; }

    public virtual Discounts Discount { get; set; }

    public virtual ICollection<OrderItems> OrderItems { get; } = new List<OrderItems>();

    public virtual ShippingOptions ShippingOption { get; set; }

    public virtual Users User { get; set; }
}