namespace PetShopClientServise.Utils.HttpClientUtils;

internal class HttpClientInfo
{
    public static readonly HttpClient HttpClientServises = new()
    {
        BaseAddress = new Uri("https://localhost:7058/")
    };
}
