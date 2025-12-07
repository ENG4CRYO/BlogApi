public interface IPostRepo : IGenericRepo<Post>
{
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(string UserId);
}

