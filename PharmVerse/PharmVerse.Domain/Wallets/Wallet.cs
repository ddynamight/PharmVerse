using PharmVerse.Domain.Common;
using PharmVerse.Domain.Users;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Wallets
{
     public class Wallet : Entity, IHasDomainEvent
     {
          public Wallet()
          {
               Histories = new HashSet<WalletHistory>();
          }

          public string AppUserId { get; set; }
          public decimal Balance { get; set; }
          public DateTime Date { get; set; }
          public DateTime LastUpdated { get; set; }
          public string Reference { get; set; }
          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Zero or One Wallet Relationship
          public virtual AppUser AppUser { get; set; }

          // One Wallet to Many Relationships
          public virtual ICollection<WalletHistory> Histories { get; set; }
     }
}
