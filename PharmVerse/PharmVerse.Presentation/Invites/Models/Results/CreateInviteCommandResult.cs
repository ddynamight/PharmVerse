using System;

namespace PharmVerse.Presentation.Invites.Models.Results
{
     public class CreateInviteCommandResult
     {
          public Guid Id { get; set; }
          public DateTime Date { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public string AppUserId { get; set; }
     }
}
