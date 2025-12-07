using AutoMapper;
using Blog.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

public class CommentRepo : GenericRepo<Comment>, ICommentRepo
{
    private readonly AppDbContext _context;


    public CommentRepo(AppDbContext context) : base(context)
    {
        _context = context;

    }


    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _context.Comments.Where(c => c.PostId == postId)
            .ToListAsync();
    }
}

