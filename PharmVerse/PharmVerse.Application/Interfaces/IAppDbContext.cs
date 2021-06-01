using Microsoft.EntityFrameworkCore;
using PharmVerse.Domain.Invites;
using PharmVerse.Domain.Models;
using PharmVerse.Domain.Notifications;
using PharmVerse.Domain.Patients;
using PharmVerse.Domain.Products;
using PharmVerse.Domain.Reviews;
using PharmVerse.Domain.Staffs;
using PharmVerse.Domain.Stocks;
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

        DbSet<Patient> Patients { get; set; } 
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Staff> Staffs { get; set; }
        DbSet<Stock> Stocks { get; set; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
     }
}
