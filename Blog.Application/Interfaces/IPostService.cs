public interface IPostService
{
    Task<PostDto> GetPostByIdAsync(int id);
    Task<IEnumerable<PostDto>> GetAllPostsAync(string userId);
    Task<PostDto> CreatePostAsync(CreatePostDto createPostDto, string userId);
    Task<PostDto> UpdatePostAsync(int id, UpdatePostDto updatePostDto, string userId);
    Task<bool> DeletePostAsync(int postId, string currentUserId, bool isAdmin);
}

