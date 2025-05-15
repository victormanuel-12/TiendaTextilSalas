using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace proyectoTienda.Servicios
{
  public class EmailSender : IEmailSender
  {
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
    {
      _configuration = configuration;
      _logger = logger;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
      var smtpSettings = _configuration.GetSection("SmtpSettings");

      var host = smtpSettings["Host"];
      var port = smtpSettings["Port"];
      var userName = smtpSettings["UserName"];
      var password = smtpSettings["Password"];
      var enableSsl = smtpSettings.GetValue<bool>("EnableSsl");

      if (string.IsNullOrEmpty(host)) throw new ArgumentNullException(nameof(host));
      if (string.IsNullOrEmpty(port)) throw new ArgumentNullException(nameof(port));
      if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
      if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

      try
      {
        using var client = new SmtpClient(host, int.Parse(port))
        {
          EnableSsl = enableSsl,
          Credentials = new NetworkCredential(userName, password)
        };

        var mailMessage = new MailMessage
        {
          From = new MailAddress(userName),
          Subject = subject,
          Body = htmlMessage,
          IsBodyHtml = true
        };
        mailMessage.To.Add(email);

        await client.SendMailAsync(mailMessage);
        _logger.LogInformation($"Correo enviado a {email}");
      }
      catch (SmtpException ex)
      {
        _logger.LogError(ex, $"Error SMTP al enviar a {email}. Status: {ex.StatusCode}");
        throw;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Error al enviar correo a {email}");
        throw;
      }
    }
  }
}