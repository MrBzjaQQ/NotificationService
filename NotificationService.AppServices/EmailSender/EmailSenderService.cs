using System.Net.Mail;
using NotificationService.AppServices.EmailSender.Contract;
using NotificationService.AppServices.EmailSender.Contract.Request;
using NotificationService.AppServices.Smtp.Contract;

namespace NotificationService.AppServices.EmailSender;

public sealed class EmailSenderService: IEmailSenderService
{
    private readonly ICshtmlToHtmlConverter _cshtmlToHtmlConverter;
    private readonly ISmtpSendService _smtpSendService;

    public EmailSenderService(ICshtmlToHtmlConverter cshtmlToHtmlConverter, ISmtpSendService smtpSendService)
    {
        _cshtmlToHtmlConverter = cshtmlToHtmlConverter;
        _smtpSendService = smtpSendService;
    }
    
    public async Task SendEmailAsync<T>(SendEmailRequest<T> request, CancellationToken cancellationToken = default)
        where T: class
    {
        var body = await _cshtmlToHtmlConverter.ConvertAsync(request.Template, request.Model);
        using var message = new MailMessage(request.From, request.To, request.Subject, body) { IsBodyHtml = true };
        await _smtpSendService.SendEmailAsync(message, cancellationToken);
    }
}