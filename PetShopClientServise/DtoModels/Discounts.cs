#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class Discounts
{
    public int DiscountId { get; set; }

    public string Code { get; set; }

    public decimal DiscountPercentage { get; set; }

    public DateTime ExpirationDate { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();
}