using Microsoft.EntityFrameworkCore;
using PetShopApiServise.Attributes.ExeptionAttributes;
using PetShopApiServise.Models;

namespace PetShopApiServise.Reposetories.Comment
{
    [PetShopExceptionFilter]
    public class CommentRepository : ICommentRepository
    {
        private readonly PetShopDBContext _context;
        private readonly ILogger<CommentRepository> _logger;

        public CommentRepository(PetShopDBContext context, ILogger<CommentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        [PetShopExceptionFilter]
        public async Task<int> AddComment(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
            return await _context.SaveChangesAsync();
        }

        [PetShopExceptionFilter]
        public async Task<int> DeleteCommentById(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            _context.Comments.Remove(comment!);
            return await _context.SaveChangesAsync();
        }

        [PetShopExceptionFilter]
        public async Task<IEnumerable<Comments>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        [PetShopExceptionFilter]
        public async Task<Comments?> GetCommentById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        [PetShopExceptionFilter]
        public async Task<int> UpdateComment(Comments comment)
        {
            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync();
        }

        [PetShopExceptionFilter]
        public async Task<IEnumerable<Comments>> GetCommentsByAnimalId(int id)
        {
            return await _context.Comments.Where(x => x.AnimalId == id).ToListAsync();
        }
    }
}
