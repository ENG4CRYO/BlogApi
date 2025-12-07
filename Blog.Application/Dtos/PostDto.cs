public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;


    public string UserName { get; set; } = default!;
    public string UserId { get; set; } = default!;


    public List<CommentDto> Comments { get; set; } = default!;
}

