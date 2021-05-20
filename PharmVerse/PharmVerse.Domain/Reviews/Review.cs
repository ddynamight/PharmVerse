using PharmVerse.Domain.Common;
using PharmVerse.Domain.Users;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Reviews
{
     public class Review : Entity, IHasDomainEvent
     {
          public DateTime Date { get; set; }
          public string Comment { get; set; }
          public int Rating { get; set; }
          public string AppUserId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Reviews Relationships
          public virtual AppUser AppUser { get; set; }
     }
}
