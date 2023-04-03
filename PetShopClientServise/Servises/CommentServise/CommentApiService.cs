using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using System.Net;
using System.Net.Http.Json;


namespace PetShopClientServise.Servises.CommentServise;

public class CommentApiService : ICommentApiService
{
    public async Task<HttpStatusCode> AddComment(Comments comment)
    {
        var response = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Comment", comment);
        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteCommentById(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Comment/{id}");
        return response.StatusCode;
    }

    public async Task<(IEnumerable<Comments> comments, HttpStatusCode statusCode)> GetAllComments()
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Comment");

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();
            return (comments!, HttpStatusCode.OK);
        }
        else
        {
            return (null!, response.StatusCode);
        }
    }

    public async Task<(Comments? comment, HttpStatusCode statusCode)> GetCommentById(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Comment/{id}");

        if (response.IsSuccessStatusCode)
        {
            var comment = await response.Content.ReadFromJsonAsync<Comments>();
            return (comment, HttpStatusCode.OK);
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return (null, HttpStatusCode.NotFound);
        }
        else
        {
            return (null, response.StatusCode);
        }
    }

    public async Task<HttpStatusCode> UpdateComment(Comments comment)
    {
        var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Comment", comment);
        return response.StatusCode;
    }

    public async Task<(IEnumerable<Comments> comments, HttpStatusCode statusCode)> GetCommentsByAnimalId(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Comment/GetCommentsByAnimalId/{id}");

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();
            return (comments!, HttpStatusCode.OK);
        }
        else
        {
            return (null!, response.StatusCode);
        }
    }

    public static async Task<(IEnumerable<Comments> comments, HttpStatusCode statusCode)> GetAllCommentsStatic()
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Comment");

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();
            return (comments!, HttpStatusCode.OK);
        }
        else
        {
            return (null!, response.StatusCode);
        }
    }
}
