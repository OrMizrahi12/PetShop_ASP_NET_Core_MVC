using System.Net;

namespace PetShopClientServise.Utils.Responses;

public class ClientResponse<T>
{
    public T ? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }

}
