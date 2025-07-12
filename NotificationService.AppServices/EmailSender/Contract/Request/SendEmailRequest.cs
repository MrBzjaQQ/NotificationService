using System.Text.Json;

namespace NotificationService.AppServices.EmailSender.Contract.Request;

public sealed record SendEmailRequest<T>
{
    public required string Subject { get; init; }
    public required string From { get; init; }
    public required string To { get; init; }
    public required string Template { get; init; }
    public required T Model { get; init; }
}