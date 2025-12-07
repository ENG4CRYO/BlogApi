using Blog.Infrastructure.Presistence;

public class UserRepo : GenericRepo<ApplicationUser>, IUserRepo
{
    private readonly AppDbContext _context;
    public UserRepo(AppDbContext context) : base(context)
    {
        _context = context;
    }

}

