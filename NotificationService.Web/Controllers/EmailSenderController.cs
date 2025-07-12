using Microsoft.AspNetCore.Mvc;
using NotificationService.AppServices.EmailSender.Contract;
using NotificationService.AppServices.EmailSender.Contract.Request;
using NotificationService.AppServices.EmailSender.Contract.Request.Example;

namespace NotificationService.Web.Controllers;

[ApiController]
[Route("api/send-email")]
public class EmailSenderController : ControllerBase
{
    private readonly IEmailSenderService _emailSender;

    public EmailSenderController(IEmailSenderService emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost("example")]
    public async Task SendExampleAsync([FromBody] SendEmailRequest<ExampleTemplateModel> request)
    {
        // TODO - Use RabbitMQ
        await _emailSender.SendEmailAsync(request, HttpContext.RequestAborted);
    }
}