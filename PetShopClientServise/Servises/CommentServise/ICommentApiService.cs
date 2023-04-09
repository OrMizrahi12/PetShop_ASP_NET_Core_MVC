using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.CommentServise
{
    public interface ICommentApiService
    {
        Task<HttpStatusCode> AddComment(Comments comment);
        Task<HttpStatusCode> DeleteCommentById(int id);
        Task<ClientResponse<IEnumerable<Comments>>> GetAllComments();
        Task<ClientResponse<Comments>> GetCommentById(int id);
        Task<HttpStatusCode> UpdateComment(Comments comment);
        Task<ClientResponse<IEnumerable<Comments>>> GetCommentsByAnimalId(int id);
    }

}
