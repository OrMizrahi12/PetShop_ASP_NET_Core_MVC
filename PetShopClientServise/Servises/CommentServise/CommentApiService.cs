using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.Attributes.ExeptionAttributes;
using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using PetShopClientServise.Utils.Responses;
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
    public async Task<ClientResponse<IEnumerable<Comments>>> GetAllComments()
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Comment");

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();
            return new ClientResponse<IEnumerable<Comments>> { Data = comments, StatusCode = HttpStatusCode.OK };
        }
        else
        {
            return new ClientResponse<IEnumerable<Comments>> { Data = new List<Comments> { }, StatusCode = response.StatusCode };
        }
    }

    [PetShopExceptionFilter]
    public async Task<ClientResponse<Comments>> GetCommentById(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Comment/{id}");

        if (response.IsSuccessStatusCode)
        {
            var comment = await response.Content.ReadFromJsonAsync<Comments>();
            return new ClientResponse<Comments> { Data = comment, StatusCode = response.StatusCode };
        }
        else
        {
            return new ClientResponse<Comments> { Data = new Comments { }, StatusCode = response.StatusCode };
        }
    }

    [PetShopExceptionFilter]
    public async Task<HttpStatusCode> UpdateComment(Comments comment)
    {
        var response = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Comment", comment);
        return response.StatusCode;
    }

    
    [PetShopExceptionFilter]
    public async Task<ClientResponse<IEnumerable<Comments>>> GetCommentsByAnimalId(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync($"api/Comment/GetCommentsByAnimalId/{id}");

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();
            return new ClientResponse<IEnumerable<Comments>> { Data = comments, StatusCode = response.StatusCode };
        }
        else
        {
            return new ClientResponse<IEnumerable<Comments>> {Data = new List<Comments> { }, StatusCode=response.StatusCode };
        }
    }

    [PetShopExceptionFilter]
    public static async Task<ClientResponse<IEnumerable<Comments>>> GetAllCommentsStatic()
    {
        var response = await HttpClientInfo.HttpClientServises.GetAsync("api/Comment");

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();

            return new ClientResponse<IEnumerable<Comments>> { Data= comments, StatusCode = response.StatusCode };
        }
        else
        {
            return new ClientResponse<IEnumerable<Comments>> { Data = new List<Comments> { }, StatusCode = response.StatusCode };       
        }
    }
}
