using PharmVerse.Domain.Common;
using PharmVerse.Domain.Users;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Invites
{
     public class Invite : Entity, IHasDomainEvent
     {
          public DateTime Date { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public string AppUserId { get; set; }


          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Invite Relationship Relationship
          public virtual AppUser AppUser { get; set; }
     }
}
