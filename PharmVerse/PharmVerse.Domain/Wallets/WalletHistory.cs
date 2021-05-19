using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Wallets
{
     public class WalletHistory : Entity, IHasDomainEvent
     {
          public decimal Amount { get; set; }
          public string Type { get; set; }
          public DateTime Date { get; set; }
          public string Reference { get; set; }
          public string Details { get; set; }
          public string WalletAppUserId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();


          // One to Many WalletHistories Relationships
          public virtual Wallet Wallet { get; set; }
     }
}
