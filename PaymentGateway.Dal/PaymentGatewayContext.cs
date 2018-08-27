using Microsoft.EntityFrameworkCore;
using PaymentGateway.Dal.EntityFrameworkMaps;
using PaymentGateway.DataContracts.LocalDb;
using System.Configuration;

namespace PaymentGateway.Dal
{
    public class PaymentGatewayContext : DbContext
    {
        public PaymentGatewayContext(DbContextOptions<PaymentGatewayContext> options)
        : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SqlConnection"].ToString());
        //}

        public DbSet<Store> Stores { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Store>().ToTable("STORE");

            modelBuilder.Entity<RelStoreAcquirer>().ToTable("REL_STORE_ACQUIRER")
                .HasKey(r => new { r.IdStore, r.IdAcquirer });

            modelBuilder.Entity<RelStoreAcquirer>()
                .HasOne(r => r.Store)
                .WithMany(r => r.RelStoreAcquirer)
                .HasForeignKey(r => r.IdStore);

            modelBuilder.Entity<RelStoreAcquirer>()
                .HasOne(r => r.Acquirer)
                .WithMany(r => r.RelStoreAcquirer)
                .HasForeignKey(r => r.IdAcquirer);

            modelBuilder.Entity<Transaction>().ToTable("TRANSACTION");

        }
    }
 
}
