using MediatR;
using PharmVerse.Domain.Invites;

namespace PharmVerse.Domain.Events.Invites
{
     public class InviteAccessedEvent : INotification
     {
          public InviteAccessedEvent(Invite invite)
          {
               Invite = invite;
          }

          public Invite Invite { get; }
     }
}