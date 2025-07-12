# NotificationService

A .NET 9.0 web service for sending email notifications using SMTP with template support.

## Features

- **Email Sending**: Send emails via SMTP with customizable templates
- **Template Support**: Use Razor templates (`.cshtml`) for email content
- **REST API**: HTTP endpoints for sending emails
- **Docker Support**: Containerized deployment
- **Development Tools**: Integration with MailDev for email testing

## Prerequisites

- .NET 9.0 SDK
- Docker and Docker Compose (for MailDev)
- SMTP server or MailDev for development

## Quick Start

### 1. Start MailDev (Development SMTP Server)

```bash
docker run -d --name maildev -p 1025:1025 -p 1080:1080 maildev/maildev
```

This starts MailDev on:
- SMTP: `localhost:1025`
- Web UI: `http://localhost:1080`

### 2. Run the Application

```bash
# Navigate to the project directory
cd NotificationService

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the web application
dotnet run --project NotificationService.Web
```

The application will be available at:
- API: `https://localhost:5186`
- Scalar UI: `https://localhost:5186/scalar/v1`

### 3. Using Docker

```bash
# Build the Docker image
docker build -t notificationservice -f NotificationService.Web/Dockerfile .

# Run the container
docker run -p 8080:8080 -p 8081:8081 -e ASPNETCORE_ENVIRONMENT=Production notificationservice
```

## Configuration

### SMTP Settings

The application uses SMTP settings from `appsettings.json`:

```json
{
  "SmtpSettings": {
    "Host": "localhost",
    "Port": 1025,
    "User": null,
    "Password": null
  }
}
```

For production, update these settings to point to your SMTP server.

### Environment Variables

You can override SMTP settings using environment variables:
- `SmtpSettings__Host`
- `SmtpSettings__Port`
- `SmtpSettings__User`
- `SmtpSettings__Password`

## API Endpoints

### Send Example Email

**POST** `/api/send-email/example`

Send an example email using the built-in template.

**Request Body:**
```json
{
  "subject": "Test Email",
  "from": "sender@example.com",
  "to": "recipient@example.com",
  "template": "MailTemplates/ExamplePageTemplate",
  "model": {
    "text": "Hello from NotificationService!"
  }
}
```

**Response:** 200 OK (no content)

## Project Structure

```
NotificationService/
├── NotificationService.AppServices/     # Business logic and services
│   ├── EmailSender/                    # Email sending functionality
│   │   ├── Contract/                   # Interfaces and DTOs
│   │   └── EmailSenderService.cs       # Main email service
│   └── Smtp/                          # SMTP implementation
├── NotificationService.Infrastructure/  # Infrastructure concerns
├── NotificationService.Web/            # Web API and controllers
│   ├── Controllers/                    # API endpoints
│   ├── Services/                       # Web-specific services
│   ├── Views/MailTemplates/           # Email templates
│   └── Program.cs                      # Application entry point
└── README.md                          # This file
```

## Email Templates

Email templates are located in `NotificationService.Web/Views/MailTemplates/` and use Razor syntax.

### Example Template

The `ExamplePageTemplate.cshtml` template demonstrates how to create email templates:

```cshtml
@model NotificationService.AppServices.EmailSender.Contract.Request.Example.ExampleTemplateModel

<!DOCTYPE html>
<html>
<head>
    <title>Example Email</title>
</head>
<body>
    <h1>Example Email</h1>
    <p>@Model.Text</p>
</body>
</html>
```

## Development

### Adding New Email Templates

1. Create a new `.cshtml` file in `NotificationService.Web/Views/MailTemplates/`
2. Create a corresponding model class in the appropriate namespace
3. Add a new endpoint in `EmailSenderController.cs`
4. Test using the API endpoint

### Testing with MailDev

1. Start MailDev using Docker
2. Send emails through the API
3. View sent emails at `http://localhost:1080`



## License

This project is licensed under the MIT License. 