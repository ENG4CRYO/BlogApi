
public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;


    public Post Post { get; set; }
    public int PostId { get; set; }


    public ApplicationUser User { get; set; }
    public string UserId { get; set; } = default!;
}
