using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.Endpoints;
using PetShopClientServise.Utils.HttpClientUtils;
using System.Net.Http.Json;
using System;
using System.Security.Policy;

namespace PetShopClientServise.Utils.CommentUtils
{
    public class CommentUtils
    {
        public static async Task<Comments> PrepereComments(int commentId, string commentTxt)
        {
            var response = await HttpClientInfo.HttpClientServises.GetAsync($"{PetShopApiEndpoints.UpdateComments}/{commentId}");
            var item = await response.Content.ReadFromJsonAsync<Comments>();

            item!.Comment = commentTxt;
            
            return item;

        }
    }
}
