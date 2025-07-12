using Microsoft.AspNetCore.Mvc;
using NotificationService.AppServices.EmailSender.Contract;
using NotificationService.AppServices.EmailSender.Contract.Request;
using NotificationService.AppServices.EmailSender.Contract.Request.Example;

namespace NotificationService.Web.Controllers;

[ApiController]
[Route("api/template-test")]
public class TemplateTestController: ControllerBase
{
    private readonly ICshtmlToHtmlConverter _templateConverter;

    public TemplateTestController(ICshtmlToHtmlConverter templateConverter)
    {
        _templateConverter = templateConverter;
    }

    [HttpPost("example")]
    public async Task<string> SendExampleAsync([FromBody] SendEmailRequest<ExampleTemplateModel> request)
    {
        return await _templateConverter.ConvertAsync(request.Template, request.Model);
    }
}