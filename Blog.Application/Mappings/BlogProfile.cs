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
        CreateMap<Comment, CommentDto>();
        CreateMap<UpdateCommentDto, Comment>();

        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName)) 
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
    }
}

