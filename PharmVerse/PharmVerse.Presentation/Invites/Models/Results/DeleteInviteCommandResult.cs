using System;

namespace PharmVerse.Presentation.Invites.Models.Results
{
     public class DeleteInviteCommandResult
     {
          public Guid Id { get; set; }
          public bool IsDeleted { get; set; }
          public string Message { get; set; }
     }
}