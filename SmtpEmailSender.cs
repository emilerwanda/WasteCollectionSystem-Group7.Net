using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class SmtpEmailSender : IEmailSender
{
    private readonly IConfiguration _config;

    public SmtpEmailSender(IConfiguration config)
    {
        _config = config;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var smtpSection = _config.GetSection("Smtp");

        var client = new SmtpClient(smtpSection["Host"], int.Parse(smtpSection["Port"] ?? "587"))
        {
            Credentials = new NetworkCredential(smtpSection["User"], smtpSection["Pass"]),
            EnableSsl = bool.Parse(smtpSection["EnableSsl"] ?? "true")
        };

        var mailMessage = new MailMessage(smtpSection["User"]!, email, subject, htmlMessage)
        {
            IsBodyHtml = true
        };

        return client.SendMailAsync(mailMessage);
    }
}
