using MediatR;
using PharmVerse.Presentation.Invites.Models.Results;

namespace PharmVerse.Presentation.Invites.Commands
{
     public class CreateInviteCommand : IRequest<CreateInviteCommandResult>
     {
          public string Name { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public string AppUserId { get; set; }
     }
}