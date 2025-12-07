using AutoMapper;

public class PostService : IPostService
{

    private readonly IPostRepo _postRepo;
    private readonly IMapper _mapper;

    public PostService(IPostRepo postRepo, IMapper mapper)
    {
        _postRepo = postRepo;
        _mapper = mapper;
    }

    public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto, string userId)
    {
        var newPost = _mapper.Map<Post>(createPostDto);
        newPost.UserId = userId;
        await _postRepo.AddAsync(newPost);
        await _postRepo.SaveChangesAsync();
        var postDto = _mapper.Map<PostDto>(newPost);
        return postDto;
    }

    public async Task<bool> DeletePostAsync(int postId, string currentUserId, bool isAdmin)
    {
        var post = _postRepo.GetByIdAsync(postId);
        if (post == null) return false;

        if (post.Result.UserId != currentUserId && !isAdmin)
        {
            return false;
        }

        _postRepo.Delete(post.Result);
        return true;
    }

    public Task<IEnumerable<PostDto>> GetAllPostsAync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<PostDto> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PostDto> UpdatePostAsync(int id, UpdatePostDto updatePostDto, string userId)
    {
        throw new NotImplementedException();
    }
}

