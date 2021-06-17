using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace PharmVerse.Infrastructure.SMS
{
  public class SMS
  {
    private string accountSid = Environment.GetEnvironmentVariable(("TWILIO_ACCOUNT_SID"));
    private string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

    private string RecipientNumber { get; set; }
    public string Body { get; set; }
    public string From { get; set; }

    public SMS(string from, string to, string body)
    {
      From = from.ToString();
      Body = body;
      RecipientNumber = to.ToString();
    }

    public async void SendSms()
    {
      TwilioClient.Init(accountSid, authToken);

      var message = MessageResource.Create(
        body: Body,
        from: new Twilio.Types.PhoneNumber(From),
        to: new Twilio.Types.PhoneNumber(RecipientNumber)
      );
      Console.WriteLine(message.Status);
    }
    
    
  }
}