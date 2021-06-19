using MediatR;
using PharmVerse.Presentation.Invites.Models.Results;
using System;

namespace PharmVerse.Presentation.Invites.Commands
{
     public class DeleteInviteCommand : IRequest<DeleteInviteCommandResult>
     {
          public Guid Id { get; set; }
     }
}