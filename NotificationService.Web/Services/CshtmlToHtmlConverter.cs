using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NotificationService.AppServices.EmailSender.Contract;

namespace NotificationService.Web.Services;

public class CshtmlToHtmlConverter: ICshtmlToHtmlConverter
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly IServiceProvider _serviceProvider;
    private readonly ITempDataProvider _tempDataProvider;

    public CshtmlToHtmlConverter(
        IRazorViewEngine razorViewEngine,
        IServiceProvider serviceProvider,
        ITempDataProvider tempDataProvider)
    {
        _razorViewEngine = razorViewEngine;
        _serviceProvider = serviceProvider;
        _tempDataProvider = tempDataProvider;
    }
    
    public async Task<string> ConvertAsync<T>(string viewName, T model)
        where T : class
    {
        var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
        var actionContext = new ActionContext(
            httpContext,
            new RouteData(),
            new ActionDescriptor());
        
        var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
        if (viewResult.View == null)
        {
            throw new InvalidOperationException($"View '{viewName}' not found.");
        }
        var viewDataDictionary = new ViewDataDictionary(
            new EmptyModelMetadataProvider(),
            new ModelStateDictionary())
        {
            Model = model
        };
        var tempDataDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
        await using var stringWriter = new StringWriter();
        var viewContext = new ViewContext(
            actionContext,
            viewResult.View,
            viewDataDictionary,
            tempDataDictionary,
            stringWriter,
            new HtmlHelperOptions()
        );
        await viewResult.View.RenderAsync(viewContext);
        return stringWriter.ToString();
    }
}