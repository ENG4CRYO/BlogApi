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
        var post = await _postRepo.GetByIdAsync(postId);
        if (post == null) return false;

        if (post.UserId != currentUserId && !isAdmin)
        {
            return false;
        }

        _postRepo.Delete(post);
        return true;
    }

    public async Task<IEnumerable<PostDto>> GetAllPostsAync(string userId)
    {
        var posts = await _postRepo.GetPostsByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<PostDto>>(posts);

    }

    public async Task<PostDto> GetPostByIdAsync(int id)
    {
        var post =await _postRepo.GetByIdAsync(id);
        return _mapper.Map<PostDto>(post);
    }

    public async Task<PostDto> UpdatePostAsync(int id, UpdatePostDto updatePostDto, string userId)
    {
        var post = await _postRepo.GetByIdAsync(id);
        if (post == null || post.UserId != userId)
        {
            return null;
        }
        _mapper.Map(updatePostDto, post);
        await _postRepo.SaveChangesAsync();
        return _mapper.Map<PostDto>(post);
    }
}

