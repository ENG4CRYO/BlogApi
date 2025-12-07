using AutoMapper;

public class CommentService : ICommentService
{
    private readonly ICommentRepo _commentRepo;
    private readonly IPostRepo _postRepo;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepo commentRepo, IMapper mapper, IPostRepo postRepo)
    {
        _postRepo = postRepo;
        _mapper = mapper;
        _commentRepo = commentRepo;
    }
    public async Task<CommentDto> AddCommentAsync(CreateCommentDto createCommentDto, string userId)
    {
       var postExists =  _postRepo.GetByIdAsync(createCommentDto.PostId);  
       if (postExists == null)
       {
            return null;
       }
       var comment = _mapper.Map<Comment>(createCommentDto);
         comment.UserId = userId;
         var createdComment = await _commentRepo.AddAsync(comment);
        await _commentRepo.SaveChangesAsync();
        return _mapper.Map<CommentDto>(createdComment);

    }

    public async Task<bool> DeleteCommentAsync(int commentId, string currentUserId, bool isAdmin)
    {
        var comment = await _commentRepo.GetByIdAsync(commentId);
        if (comment == null) return false;

    
        if (!isAdmin && comment.UserId != currentUserId)
        {
            return false;
        }

        _commentRepo.Delete(comment);
        return true;
    }

    public async Task<CommentDto> GetCommentByIdAsync(int id)
    {
        var comment = await _commentRepo.GetByIdAsync(id);
        if (comment == null)
        {
            return null;
        }
        return _mapper.Map<CommentDto>(comment);
    }

    public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(int postId)
    {
        var comment = await _commentRepo.GetCommentsByPostIdAsync(postId);
        if (comment == null)
        {
            return null;
        }
        return _mapper.Map<IEnumerable<CommentDto>>(comment);
    }

    public async Task<CommentDto> UpdateCommentAsync(int id, UpdateCommentDto updateCommentDto, string userId)
    {
        var comment = await _commentRepo.GetByIdAsync(id);   
        if (comment == null) return null;

        if (updateCommentDto.UserId != userId)
        {
            return null;
        }

        var updatedComment = _mapper.Map(updateCommentDto, comment);
        _commentRepo.Update(updatedComment);
        await _commentRepo.SaveChangesAsync();
        return _mapper.Map<CommentDto>(updatedComment);
    }
}

