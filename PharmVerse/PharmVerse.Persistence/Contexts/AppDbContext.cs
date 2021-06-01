using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using PharmVerse.Application.Interfaces;
using PharmVerse.Domain.Invites;
using PharmVerse.Domain.Notifications;
using PharmVerse.Domain.Reviews;
using PharmVerse.Domain.Transactions;
using PharmVerse.Domain.Users;
using PharmVerse.Domain.Wallets;
using PharmVerse.Domain.Models;
using PharmVerse.Domain.Patients;
using PharmVerse.Domain.Products;
using PharmVerse.Domain.Staffs;
using PharmVerse.Domain.Stocks;

namespace PharmVerse.Persistence.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

          
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> WalletHistories { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
           


          public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               /*
               foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
               {
                    switch (entry.State)
                    {
                         case EntityState.Added:
                              entry.Entity.CreatedBy = _currentUserService.UserId;
                              entry.Entity.Created = _dateTime.Now;
                              break;

                         case EntityState.Modified:
                              entry.Entity.LastModifiedBy = _currentUserService.UserId;
                              entry.Entity.LastModified = _dateTime.Now;
                              break;
                    }
               }
               */

               var result = await base.SaveChangesAsync(cancellationToken);

               //await DispatchEvents();

               return result;
          }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
          } 

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
               IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{envName}.json", optional: true)
                    .Build();
               optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          }

          /*
          private async Task DispatchEvents()
          {
               var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished);

               foreach (var domainEvent in domainEventEntities)
               {
                    domainEvent.IsPublished = true;
                    await _domainEventService.Publish(domainEvent);
               }
          }
          */
     }
}
