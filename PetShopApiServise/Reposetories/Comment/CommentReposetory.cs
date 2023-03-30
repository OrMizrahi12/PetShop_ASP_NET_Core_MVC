using Microsoft.EntityFrameworkCore;
using PetShopApiServise.Models;

namespace PetShopApiServise.Reposetories.Comment
{
    public class CommentReposetory : ICommentReposetory
    {
        private readonly PetShopDBContext _context;
        private readonly ILogger<CommentReposetory> _logger;


        public CommentReposetory(PetShopDBContext context, ILogger<CommentReposetory> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> AddComment(Comments comment)
        {
            try
            {
                await _context.Comments.AddAsync(comment);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return -1;
            }
        }

        public async Task<int> DeleteCommentById(int commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return -1;
            }
        }

        public async Task<IEnumerable<Comments>> GetAllComments()
        {
            try
            {
                return await _context.Comments.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Enumerable.Empty<Comments>();
            }
        }

        public async Task<Comments?> GetCommentById(int id)
        {
            try
            {
                return await _context.Comments.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return null;
            }
        }

        public async Task<int> UpdateComment(Comments comment)
        {
            try
            {
                _context.Comments.Update(comment);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return -1;
            }
        }
    }
}
