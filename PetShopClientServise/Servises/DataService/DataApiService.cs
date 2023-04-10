using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Responses;
using System.Net;
using System.Net.Http.Json;

namespace PetShopClientServise.Servises.DataService;

[PetShopExceptionFilter]
public class DataApiService<T> : IDataApiService<T>
{
    public async Task<HttpStatusCode> Delete(string url, int id)
    {
        var res = await HttpClientInfo.HttpClientServises.DeleteAsync($"{url}/{id}");
        return res.StatusCode;
    }

    public async Task<ClientResponse<IEnumerable<T>>> GetAll(string url)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync(url);

        var item = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();

        return new ClientResponse<IEnumerable<T>>
        {
            Data = item,
            StatusCode = response.StatusCode
        };
    }

    public async Task<ClientResponse<IEnumerable<T>>> GetAllById(string url, int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"{url}/{id}");

        var elements = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();

        return new ClientResponse<IEnumerable<T>>
        {
            Data = elements,
            StatusCode = response.StatusCode
        };
    }

    public async Task<ClientResponse<T>> GetById(string url, int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"{url}/{id}");

        var item = await response.Content.ReadFromJsonAsync<T>();

        return new ClientResponse<T>
        {
            Data = item,
            StatusCode = response.StatusCode
        };
    }

    public async Task<HttpStatusCode> Post(string url, T item)
    {
        var response = await HttpClientInfo.HttpClientServises.PostAsJsonAsync(url, item);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> Put(string url, T item)
    {
        var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync(url, item);

        return response.StatusCode;
    }
}
