using AutoMapper;
using Blog.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

public class PostRepo : GenericRepo<Post>, IPostRepo
{
    private readonly AppDbContext _context;
    public PostRepo(AppDbContext context) : base(context)
    {
        _context = context;
      
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(string UserId)
    {
        return await _context.Posts.Where(p => p.UserId == UserId).Include(p => p.Comments)
            .ToListAsync();
    }


}

