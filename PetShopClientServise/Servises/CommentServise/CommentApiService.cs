using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using System.Net;
using System.Net.Http.Json;


namespace PetShopClientServise.Servises.CommentServise;

public class CommentApiService : ICommentApiService
{

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> AddComment(Comments comment)
    {
        var response = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Comment", comment);
        return response.StatusCode;
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> DeleteCommentById(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Comment/{id}");
        return response.StatusCode;
    }

    [PetShopExceptionFilter]
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
            return (new List<Comments> { }, response.StatusCode);
        }
    }

    [PetShopExceptionFilter]
    public async Task<(Comments? comment, HttpStatusCode statusCode)> GetCommentById(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Comment/{id}");

        if (response.IsSuccessStatusCode)
        {
            var comment = await response.Content.ReadFromJsonAsync<Comments>();
            return (comment, HttpStatusCode.OK);
        }
        else
        {
            return (new Comments { }, response.StatusCode);
        }
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> UpdateComment(Comments comment)
    {
        var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Comment", comment);
        return response.StatusCode;
    }

    [PetShopExceptionFilter]
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
            return (new List<Comments> { }, response.StatusCode);
        }
    }

    [PetShopExceptionFilter]
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
            return (new List<Comments> { }, response.StatusCode);
        }
    }


}
