using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace proyectoTienda.Servicios
{
  public class EmailSender : IEmailSender
  {
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
      var smtpClient = new SmtpClient
      {
        Host = _configuration["EmailSettings:SmtpServer"],
        Port = int.Parse(_configuration["EmailSettings:Port"]),
        EnableSsl = true,
        Credentials = new NetworkCredential(
              _configuration["EmailSettings:FromEmail"],
              _configuration["EmailSettings:Password"])
      };

      var mailMessage = new MailMessage
      {
        From = new MailAddress(_configuration["EmailSettings:FromEmail"], "Tu Nombre o App"),
        Subject = subject,
        Body = htmlMessage,
        IsBodyHtml = true
      };

      mailMessage.To.Add(email);

      return smtpClient.SendMailAsync(mailMessage);
    }
  }
}
