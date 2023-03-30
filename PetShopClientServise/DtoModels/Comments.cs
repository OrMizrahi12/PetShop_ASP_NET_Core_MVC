#nullable disable


namespace PetShopApiServise.DtoModels;

public partial class Comments
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? AnimalId { get; set; }

    public string CommentText { get; set; }

    public DateTime CommentDate { get; set; }

    public virtual Animals Animal { get; set; }

    public virtual PetProducts Product { get; set; }

    public virtual Users User { get; set; }
}