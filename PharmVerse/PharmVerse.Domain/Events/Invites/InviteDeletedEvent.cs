using MediatR;
using PharmVerse.Domain.Invites;

namespace PharmVerse.Domain.Events.Invites
{
     public class InviteDeletedEvent : INotification
     {
          public InviteDeletedEvent(Invite invite)
          {
               Invite = invite;
          }

          public Invite Invite { get; }
     }
}