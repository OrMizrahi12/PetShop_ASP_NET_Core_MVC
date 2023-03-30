#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class PetSales
{
    public int SaleId { get; set; }

    public int? UserId { get; set; }

    public int? AnimalId { get; set; }

    public DateTime SaleDate { get; set; }

    public decimal Price { get; set; }

    public virtual Animals Animal { get; set; }

    public virtual Users User { get; set; }
}