using NotificationService.AppServices.Settings;

namespace NotificationService.Web.Settings;

public sealed record AppSettings
{
    public SmtpSettings? SmtpSettings { get; init; }
}