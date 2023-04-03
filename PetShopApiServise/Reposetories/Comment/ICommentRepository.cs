using PetShopApiServise.Models;

namespace PetShopApiServise.Reposetories.Comment
{
    public interface ICommentRepository
    {
        Task<Comments?> GetCommentById(int id);
        Task<int> AddComment(Comments comment);
        Task<int> UpdateComment(Comments comment);
        Task<int> DeleteCommentById(int commentId);
        Task<IEnumerable<Comments>> GetAllComments();
        Task<IEnumerable<Comments>> GetCommentsByAnimalId(int id);
    }
}
