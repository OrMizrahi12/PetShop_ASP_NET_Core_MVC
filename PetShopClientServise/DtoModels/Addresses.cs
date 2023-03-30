#nullable disable

namespace PetShopApiServise.DtoModels;

public partial class Addresses
{
    public int AddressId { get; set; }

    public int? UserId { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();

    public virtual Users User { get; set; }
}