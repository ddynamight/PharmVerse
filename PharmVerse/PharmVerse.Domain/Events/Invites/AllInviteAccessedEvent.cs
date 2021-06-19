using MediatR;
using PharmVerse.Domain.Invites;
using System.Collections.Generic;

namespace PharmVerse.Domain.Events.Invites
{
     public class AllInviteAccessedEvent : INotification
     {
          public AllInviteAccessedEvent(List<Invite> invites)
          {
               Invites = invites;
          }

          public List<Invite> Invites { get; }
     }
}