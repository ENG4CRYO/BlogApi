using AutoMapper;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        //Auth Map
        CreateMap<RegisterModel, AuthModel>();
        CreateMap<ApplicationUser, AuthModel>();
        CreateMap<RegisterModel, ApplicationUser>();

        //Blog Map
        CreateMap<CreatePostDto, Post>();
        CreateMap<Post, PostDto>();
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<CommentDto, Comment>();
        CreateMap<UpdateCommentDto, Comment>();
    }
}

