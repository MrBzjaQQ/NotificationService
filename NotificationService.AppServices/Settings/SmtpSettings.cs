namespace NotificationService.AppServices.Settings;

public sealed record SmtpSettings
{
    public required string Host { get; init; }
    public required int Port { get; init; }
    public string? User { get; init; }
    public string? Password { get; init; }
}