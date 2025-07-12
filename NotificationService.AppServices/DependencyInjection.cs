using Microsoft.Extensions.DependencyInjection;
using NotificationService.AppServices.EmailSender;
using NotificationService.AppServices.EmailSender.Contract;
using NotificationService.AppServices.Smtp;
using NotificationService.AppServices.Smtp.Contract;

namespace NotificationService.AppServices;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddTransient<ISmtpSendService, SmtpSendService>();
        services.AddTransient<IEmailSenderService, EmailSenderService>();
        return services;
    } 
}