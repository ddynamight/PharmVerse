using PharmVerse.Domain.Common;
using PharmVerse.Domain.Users;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Notifications
{
     public class Notification : Entity, IHasDomainEvent
     {
          public DateTime Date { get; set; }
          public bool IsRead { get; set; }
          public string Url { get; set; }
          public string Message { get; set; }
          public string AppUserId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          //One to Many Notification Relationship
          public virtual AppUser AppUser { get; set; }
     }
}
