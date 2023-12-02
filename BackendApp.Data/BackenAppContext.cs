using BackendApp.Core.Enteties;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Data;

public class BackenAppContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionRequest> TransactionRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source = BackendAppDb.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().ToTable("Accounts").HasKey(p => p.Account_id);
        modelBuilder.Entity<Transaction>().ToTable("Transactions").HasKey(p => p.Transaction_id);
        modelBuilder.Entity<TransactionRequest>().ToTable("Requests").HasKey(p => p.Request_id);
    }
}
