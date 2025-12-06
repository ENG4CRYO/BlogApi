using AutoMapper;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<RegisterModel, AuthModel>();
        CreateMap<ApplicationUser, AuthModel>();
        CreateMap<RegisterModel, ApplicationUser>();
    }
}

