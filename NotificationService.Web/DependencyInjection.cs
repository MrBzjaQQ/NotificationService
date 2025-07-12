using NotificationService.AppServices;
using NotificationService.AppServices.EmailSender.Contract;
using NotificationService.Infrastructure;
using NotificationService.Web.Services;

namespace NotificationService.Web;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddWebServices();
        services.ConfigureAppServices();
        services.ConfigureInfrastructure();

        services.AddControllersWithViews();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        return services;
    }

    private static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddTransient<ICshtmlToHtmlConverter, CshtmlToHtmlConverter>();
        return services;
    }
}