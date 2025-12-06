
using System.ComponentModel.DataAnnotations;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;   
    public string Content { get; set; } = default!;

    public ApplicationUser User { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public List<Comment> Comments { get; set; } = default!;

}

