namespace NotificationService.AppServices.EmailSender.Contract;

public interface ICshtmlToHtmlConverter
{
    Task<string> ConvertAsync<T>(string viewName, T model)
        where T : class;
}