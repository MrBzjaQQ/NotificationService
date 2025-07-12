using NotificationService.AppServices.EmailSender.Contract.Request;

namespace NotificationService.AppServices.EmailSender.Contract;

public interface IEmailSenderService
{
    Task SendEmailAsync<T>(SendEmailRequest<T> request, CancellationToken cancellationToken = default) where T: class;
}