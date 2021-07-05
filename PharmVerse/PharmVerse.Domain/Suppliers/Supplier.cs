using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Models
{
     public class Supplier : Entity, IHasDomainEvent
     {
          public string Name { get; set; }
          public string Address { get; set; }
          public string City { get; set; }
          public string State { get; set; }
          public string Country { get; set; }
          public string Phone { get; set; }
          public string Email { get; set; }
          public DateTime Added { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

     }
}
