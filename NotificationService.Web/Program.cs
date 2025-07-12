using NotificationService.AppServices.Settings;
using NotificationService.Web;
using NotificationService.Web.Settings;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.Get<AppSettings>() ?? throw new ArgumentNullException("AppSettings");

builder.Services.AddSingleton(appSettings.SmtpSettings ?? throw new ArgumentNullException("SmtpSettings"));
builder.Services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapScalarApiReference();
app.MapControllers();

app.Run();