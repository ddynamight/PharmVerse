using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace PharmVerse.Infrastructure.Mail
{
  public class Mail
  {
    //private readonly IConfiguration _config;
    private string From { get; set; }
    private string To { get; set; }
    private string Name { get; set; }
    private string Subject { get; set; }
    private string Body { get; set; }

    private string Heading { get; set; }

    public Mail(string from, string to, string subject, string name, string body, string heading)
    {
      From = from.ToLower();
      To = to.ToLower();
      Subject = subject;
      Body = body;
      Name = name;
      Heading = heading.ToUpper();
    }

    public async Task<Response> SendMail()
    {
      var fullName = Name == "" ? Name : From.Split("@")[0].ToUpper();
      var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
      var client = new SendGridClient(apiKey);
      var from = new EmailAddress(From, fullName);
      var subject = Subject;
      var to = new EmailAddress(To);
      var heading = Heading;
      var body = Body;
      var mail = MailHelper.CreateSingleEmail(from, to, subject, heading, body);
      var response = await client.SendEmailAsync(msg: mail);
      return response;
    }
  }
}