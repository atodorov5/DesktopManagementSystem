using ManagementSystem.Data;
using ManagementSystem.Models;

namespace ManagementSystem.Services
{
    public class CommentService : ICommentService
    {
        public AppDbContext _context;

        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewCommentAsync(CommentEntity commentEntity)
        {
            var newComment = await _context.Comments.AddAsync(commentEntity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCommentAsync(Guid commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
