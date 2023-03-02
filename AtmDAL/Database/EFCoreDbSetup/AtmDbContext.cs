using AtmDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmDAL.Database.EFCoreDbSetup
{
    public class AtmDbContext : DbContext
    {
        public AtmDbContext(DbContextOptions<AtmDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Atm> Atms { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(property => property.Email).IsRequired(true).HasMaxLength(100);
                entity.Property(property => property.FullName).IsRequired(true).HasMaxLength(100);
                entity.Property(property => property.UpdatedDate).IsRequired(false);
                entity.Property(property => property.Concurrency).IsRequired(false);
                entity.HasIndex(property => new { property.Email, property.PhoneNumber }, $"IX_Unique_{nameof(User.Email)}{nameof(User.PhoneNumber)}").IsUnique();
            }
            );

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(property => new { property.AccountNo, property.Id }, $"IX_Unique_{nameof(Account.AccountNo)}{nameof(Account.Id)}").IsUnique();
                entity.Property(property => property.AccountNo).IsRequired(true).HasMaxLength(100);
                entity.Property(property => property.Concurrency).IsRequired(false);
                entity.Property(property => property.UpdatedDate).IsRequired(false);
                entity.Property(property => property.Pin).HasMaxLength(4);
                entity.Property(property => property.Balance).HasColumnType("decimal(18,2)").HasPrecision(18);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(property => property.Id, $"IX_Unique_{nameof(Transaction.Id)}").IsUnique();
                entity.Property(property => property.TransactionAmount).HasColumnType("decimal(18,2)").HasPrecision(18);
                entity.Property(property => property.UpdatedDate).IsRequired(false);
                entity.Property(property => property.Concurrency).IsRequired(false);
            });

            modelBuilder.Entity<Atm>(entity =>
            {
                entity.HasIndex(property => property.Id, $"IX_Unique_{nameof(Atm.Id)}").IsUnique();
                entity.Property(property => property.AvailableCash).HasColumnType("decimal(18, 2)").HasPrecision(18);
                entity.Property(property => property.UpdatedDate).IsRequired(false);
                entity.Property(property => property.Concurrency).IsRequired(false);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasIndex(property => new { property.Id, property.Name }, $"IX_Unique_{nameof(Bill.Id)}{nameof(Bill.Name)}").IsUnique();
                entity.Property(property => property.Amount).HasColumnType("decimal(18, 2)").HasPrecision(18);
                entity.Property(property => property.UpdatedDate).IsRequired(false);
                entity.Property(property => property.Concurrency).IsRequired(false);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasIndex(property => new { property.Id, property.SwiftCode }, $"IX_Unique_{nameof(Bank.Id)}{nameof(Bank.SwiftCode)}").IsUnique();
                entity.Property(property => property.UpdatedDate).IsRequired(false);
                entity.Property(property => property.Concurrency).IsRequired(false);
            });
        }
    }
}
