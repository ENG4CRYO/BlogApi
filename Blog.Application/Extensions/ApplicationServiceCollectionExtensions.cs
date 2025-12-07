using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

public static class ApplicationServiceCollectionExtensions 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IPostService, PostService>();
        service.AddScoped<ICommentService, CommentService>();
        service.AddAutoMapper(cfg => cfg.AddProfile<BlogProfile>());
        return service;
    }
}

