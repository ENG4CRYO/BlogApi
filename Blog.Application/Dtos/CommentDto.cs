public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public int PostId { get; set; }
}

