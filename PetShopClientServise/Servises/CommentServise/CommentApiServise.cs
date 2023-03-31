using PetShopApiServise.DtoModels;
using PetShopClientServise.Utils.HttpClientUtils;
using System.Net.Http.Json;


namespace PetShopClientServise.Servises.CommentServise;

public class CommentApiServise : ICommentApiServise
{
    public async Task<int> AddComment(Comments comment)
    {
        comment.CommentDate = DateTime.Now;
        var res = await HttpClientInfo.HttpClientServises.PostAsJsonAsync("api/Comment", comment);
        return res.IsSuccessStatusCode ? 0 : 1;
    }

    public async Task<int> DeleteCommentById(int id)
    {
        var response = await HttpClientInfo.HttpClientServises.DeleteAsync($"api/Comment/{id}");
        return response.IsSuccessStatusCode ? 0 : 1;
    }

    public async Task<IEnumerable<Comments>> GetAllComments()
    {
        var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<List<Comments>?>("api/Comment");
        return res!;
    }

    public async Task<Comments> GetCommentById(int id)
    {
        var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<Comments?>($"api/Comment/{id}");
        return res!;
    }

    public async Task<int> UpdateComment(Comments comment)
    {
        var res = await HttpClientInfo.HttpClientServises.PutAsJsonAsync("api/Comment", comment);
        return res.IsSuccessStatusCode ? 0 : 1;
    }

    public async Task<IEnumerable<Comments>> GetCommentsByAnimalId(int id)
    {
        var res = await HttpClientInfo.HttpClientServises.GetFromJsonAsync<List<Comments>?>($"api/Comment/GetCommentsByAnimalId/{id}");
        return res!;
    }

}
