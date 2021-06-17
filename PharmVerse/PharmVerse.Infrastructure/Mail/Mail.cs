using System;
using System.Net;
using System.Net.Mime;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace PharmVerse.Infrastructure.Mail
{
  public class Mail
  {
    //private readonly IConfiguration _config;
    public string From { get; set; }
    public string To { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    
    public string Heading { get; set; }

    public Mail(string from, string to, string subject, string name, string body, string heading)
    {
      From = from.ToLower();
      To = to.ToLower();
      Subject = subject;
      Body = body;
      Name = name;
      Heading = heading.ToUpper();
    }

    async Task SendMail()
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
    }
  }
}