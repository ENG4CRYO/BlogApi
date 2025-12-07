public class UpdateCommentDto
{
    public string Content { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public int PostId { get; set; }
}

