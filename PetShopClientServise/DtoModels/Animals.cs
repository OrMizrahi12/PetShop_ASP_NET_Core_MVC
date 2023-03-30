#nullable disable

using Microsoft.AspNetCore.Http;

namespace PetShopApiServise.DtoModels;

public partial class Animals
{
    public int AnimalId { get; set; }

    public string Name { get; set; }


    public int Age { get; set; }

    public IFormFile ImageFile { get; set; }

    public byte[] Image { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; }

    public virtual Categories Category { get; set; }

    public virtual ICollection<Comments> Comments { get; } = new List<Comments>();

    public virtual ICollection<PetSales> PetSales { get; } = new List<PetSales>();
}