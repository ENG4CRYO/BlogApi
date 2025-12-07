
public interface ICommentService
{
    Task <CommentDto> GetCommentByIdAsync(int id);
    Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId);
    Task<Comment> AddCommentAsync(CreateCommentDto createCommentDto, string userId);
    Task<CommentDto> UpdateCommentAsync(int id, UpdateCommentDto updateCommentDto, string userId);
    Task<bool> DeleteCommentAsync(int commentId, string currentUserId, bool isAdmin);
}

