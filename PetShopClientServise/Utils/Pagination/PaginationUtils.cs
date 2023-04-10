namespace PetShopClientServise.Utils.Pagination;

public class PaginationUtils
{
    public static int GetPageCount(int itemsCount, int pageSize)
    {
        return (int)Math.Ceiling(itemsCount / (double)pageSize);
    }

    public static int PageNumber { get; set; } = 1;
    public static int PageSize { get; set; } = 10;
}
