using Microsoft.EntityFrameworkCore;
using PharmVerse.Domain.Invites;
using PharmVerse.Domain.Notifications;
using PharmVerse.Domain.Reviews;
using PharmVerse.Domain.Transactions;
using PharmVerse.Domain.Users;
using PharmVerse.Domain.Wallets;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Application.Interfaces
{
     public interface IAppDbContext
     {

          DbSet<Invite> Invites { get; set; }
          DbSet<Notification> Notifications { get; set; }
          DbSet<Review> Reviews { get; set; }
          DbSet<Setting> Settings { get; set; }
          DbSet<Transaction> Transactions { get; set; }
          DbSet<Wallet> Wallets { get; set; }
          DbSet<WalletHistory> WalletHistories { get; set; }


          Task<int> SaveChangesAsync(CancellationToken cancellationToken);
     }
}
