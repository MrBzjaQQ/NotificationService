using System.Net;
using NotificationService.AppServices.Smtp.Contract;
using System.Net.Mail;
using NotificationService.AppServices.Settings;

namespace NotificationService.AppServices.Smtp;

public sealed class SmtpSendService: ISmtpSendService
{
    private readonly SmtpSettings _smtpSettings;

    public SmtpSendService(SmtpSettings smtpSettings)
    {
        _smtpSettings = smtpSettings;
    }
    
    public async Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken = default)
    {
        using var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port);
        if (!string.IsNullOrEmpty(_smtpSettings.User) && !string.IsNullOrEmpty(_smtpSettings.Password))
        {
            client.Credentials = new NetworkCredential(_smtpSettings.User, _smtpSettings.Password);
        }
        
        client.EnableSsl = false; // TODO - true
        await client.SendMailAsync(mailMessage, cancellationToken);
    }
}