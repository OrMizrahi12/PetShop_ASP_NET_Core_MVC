using PetShopApiServise.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.CommentServise
{
    public interface ICommentApiServise
    {
        Task<int> AddComment(Comments comment);
        Task<int> DeleteCommentById(int id);
        Task<IEnumerable<Comments>> GetAllComments();
        Task<Comments> GetCommentById(int id);
        Task<int> UpdateComment(Comments comment);
        Task<IEnumerable<Comments>> GetCommentsByAnimalId(int id);
        
    }
}
