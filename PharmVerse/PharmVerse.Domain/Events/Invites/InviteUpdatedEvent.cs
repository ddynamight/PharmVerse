using MediatR;
using PharmVerse.Domain.Invites;

namespace PharmVerse.Domain.Events.Invites
{
     public class InviteUpdatedEvent : INotification
     {
          public InviteUpdatedEvent(Invite invite)
          {
               Invite = invite;
          }

          public Invite Invite { get; }
     }
}