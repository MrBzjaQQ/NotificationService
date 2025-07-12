namespace NotificationService.AppServices.EmailSender.Contract.Request.Example;

public sealed record ExampleTemplateModel
{
    public required string Text { get; init; }
}