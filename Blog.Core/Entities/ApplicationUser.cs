using Microsoft.AspNetCore.Identity;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }

}

