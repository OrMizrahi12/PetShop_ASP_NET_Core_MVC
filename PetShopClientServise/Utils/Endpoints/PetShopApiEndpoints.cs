namespace PetShopClientServise.Utils.Endpoints;

public class PetShopApiEndpoints
{
    public static readonly string GetAllAnimal = "api/Animal";
    public static readonly string GetAnimalById = "api/Animal";
    public static readonly string AddAnimal = "api/Animal";
    public static readonly string UpdateAnimal = "api/Animal/UpdateAnimal";
    public static readonly string DeleteAnimalById = "api/Animal";
    public static readonly string GetAnimalByCategory = "api/Animal/GetAnimalsByCategory";

    public static readonly string GetAllCategory = "api/Category";
    public static readonly string GetCategoryById = "api/Category";
    public static readonly string AddCategory = "api/Category";
    public static readonly string UpdateCategory = "api/Category";
    public static readonly string DeleteCategoryById = "api/Category";

    public static readonly string GetAllComments = "api/Comment";  
    public static readonly string GetCommentsById = "api/Comment";
    public static readonly string AddComments = "api/Comment";
    public static readonly string UpdateComments = "api/Comment";
    public static readonly string DeleteCommentsById = "api/Comment";
    public static readonly string GetCommentsByAnimalId = "api/Comment/GetCommentsByAnimalId";
}
