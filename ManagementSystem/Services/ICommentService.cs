using ManagementSystem.Models;

namespace ManagementSystem.Services
{
    public interface ICommentService
    {
        Task AddNewCommentAsync(CommentEntity commentEntity);
        Task RemoveCommentAsync(Guid commentId);
    }
}
