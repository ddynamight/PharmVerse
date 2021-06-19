using MediatR;
using PharmVerse.Domain.Invites;

namespace PharmVerse.Domain.Events.Invites
{
     public class InviteCreatedEvent : INotification
     {
          public InviteCreatedEvent(Invite invite)
          {
               Invite = invite;
          }

          public Invite Invite { get; }
     }
}