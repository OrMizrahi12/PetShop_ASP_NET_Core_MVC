using PetShopClientServise.Utils.Responses;
using System.Net;

namespace PetShopClientServise.Servises.DataService;

public interface IDataApiService<T>
{
    public Task<ClientResponse<T>> GetById(string url, int id);
    public Task<HttpStatusCode> Post(string url, T item);
    public Task<HttpStatusCode> Put(string url, T item);
    public Task<HttpStatusCode> Delete(string url, int id);
    public Task<ClientResponse<IEnumerable<T>>> GetAll(string url);
    public Task<ClientResponse<IEnumerable<T>>> GetAllById(string url, int id);
}
