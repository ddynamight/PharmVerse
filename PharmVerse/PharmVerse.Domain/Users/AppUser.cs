using Microsoft.AspNetCore.Identity;
using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;
using PharmVerse.Domain.Invites;
using PharmVerse.Domain.Notifications;
using PharmVerse.Domain.Reviews;
using PharmVerse.Domain.Wallets;
using PharmVerse.Domain.Transactions;

namespace PharmVerse.Domain.Users
{
     public class AppUser : IdentityUser, IHasDomainEvent
     {
          public string Title { get; set; }
          public string FirstName { get; set; }
          public string MiddleName { get; set; }
          public string LastName { get; set; }
          public string Image { get; set; }
          public string Address { get; set; }
          public string Area { get; set; }
          public string State { get; set; }
          public string Country { get; set; }
          public bool IsLockedOut { get; set; }
          public DateTime LastOnline { get; set; }
          public bool IsVerified { get; set; }
          public bool IsArchived { get; set; }
          public bool Active { get; set; }
          public string ReferralCode { get; set; }
          public string InviteCode { get; set; }

          public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();


          // One AppUser to Zero or One Relationship
          public virtual Setting Setting { get; set; }
          public virtual Wallet Wallet { get; set; }

          // One AppUser to Many Relationship
          public virtual ICollection<Invite> Invites { get; set; } = new HashSet<Invite>();
          public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
          public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
          public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
     }
}
