using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Users
{
     public class Setting : Entity, IHasDomainEvent
     {
          public string AppUserId { get; set; }
          public DateTime Date { get; set; }
          public bool WantNewsletter { get; set; }
          public bool SmsNotification { get; set; }
          public bool EmailNotification { get; set; }
          public bool InAppNotification { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          //One to One Settings Relationship
          public virtual AppUser AppUser { get; set; }
     }
}
