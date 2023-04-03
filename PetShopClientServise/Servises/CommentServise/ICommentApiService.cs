using PetShopClientServise.DtoModels;
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
        Task<(IEnumerable<Comments> comments, HttpStatusCode statusCode)> GetAllComments();
        Task<(Comments? comment, HttpStatusCode statusCode)> GetCommentById(int id);
        Task<HttpStatusCode> UpdateComment(Comments comment);
        Task<(IEnumerable<Comments> comments, HttpStatusCode statusCode)> GetCommentsByAnimalId(int id);
    }

}
