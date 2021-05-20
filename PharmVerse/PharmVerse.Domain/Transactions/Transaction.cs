using PharmVerse.Domain.Common;
using PharmVerse.Domain.Users;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Transactions
{
     public class Transaction : Entity, IHasDomainEvent
     {
          public DateTime Date { get; set; }
          public string Description { get; set; }
          public string Type { get; set; }
          public string Channel { get; set; }
          public decimal Amount { get; set; }
          public bool IsSuccessful { get; set; }
          public string Reference { get; set; }
          public string IpAddress { get; set; }
          public string Currency { get; set; }
          public string Vendor { get; set; }
          public string AppUserId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Transaction Relationship
          public virtual AppUser AppUser { get; set; }
     }
}
