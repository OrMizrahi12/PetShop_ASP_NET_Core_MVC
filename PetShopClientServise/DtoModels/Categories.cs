#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class Categories
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public virtual ICollection<Animals> Animals { get; } = new List<Animals>();

    public virtual ICollection<PetProducts> PetProducts { get; } = new List<PetProducts>();
}