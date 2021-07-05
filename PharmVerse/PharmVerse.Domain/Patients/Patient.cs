using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;
using PharmVerse.Domain.Users;

namespace PharmVerse.Domain.Patients
{
     public class Patient : Entity, IHasDomainEvent
     {
          public string AppUserId { get; set; }
          public string Number { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Zero or One Tutor Relationship
          public virtual AppUser AppUser { get; set; }
     }
}