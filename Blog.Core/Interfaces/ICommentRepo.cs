
public interface ICommentRepo : IGenericRepo<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);

}

