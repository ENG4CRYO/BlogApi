
public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;


    public Post Post { get; set; } = default!;
    public int PostId { get; set; }


    public ApplicationUser User { get; set; } = default!;
    public string UserId { get; set; } = default!;
}
