using MediatR;
using PharmVerse.Presentation.Invites.Models.Results;
using System;

namespace PharmVerse.Presentation.Invites.Commands
{
     public class UpdateInviteCommand : IRequest<UpdateInviteCommandResult>
     {
          public Guid Id { get; set; }
          public DateTime Date { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public string AppUserId { get; set; }
     }
}