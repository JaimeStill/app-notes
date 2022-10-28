using Microsoft.Extensions.DependencyInjection;

namespace AppNotes.Services.Api;
public static class ServiceRegistrant
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddTransient<AlbumService>();
        services.AddTransient<BookService>();        
    }
}