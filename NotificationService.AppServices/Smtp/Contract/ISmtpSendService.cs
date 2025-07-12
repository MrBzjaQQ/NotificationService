using System.Net.Mail;

namespace NotificationService.AppServices.Smtp.Contract;

public interface ISmtpSendService
{
    Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken = default);
}