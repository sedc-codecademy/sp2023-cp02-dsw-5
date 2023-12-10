using Microsoft.EntityFrameworkCore;
using Shipfinity.Domain.Models;

namespace Shipfinity.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ReviewProduct> ProductReviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.ProductOrders)
                .WithOne(p => p.Order)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductOrders)
                .WithOne(p => p.Product)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Seller>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductReviews)
                .WithOne(rp => rp.Product)
                .HasForeignKey(rp => rp.ProductId);
           
            modelBuilder.Entity<ReviewProduct>()
                .HasOne(rp => rp.Customer)
                .WithMany(c => c.ReviewProducts)
                .HasForeignKey(rp => rp.CustomerId);

            modelBuilder.Entity<Address>()
                .HasMany(a => a.Customers)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId);

            modelBuilder.Entity<PaymentInfo>()
                .HasMany(pi => pi.Orders)
                .WithOne(o => o.PaymentInfo)
                .HasForeignKey(o => o.PaymentInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentInfo>()
                .HasOne(pi => pi.Customer)
                .WithMany(c => c.PaymentInfos)
                .HasForeignKey(pi => pi.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentInfo>().HasIndex(p => p.CustomerId);
            modelBuilder.Entity<PaymentInfo>().HasIndex(p => p.CardNumber);
            modelBuilder.Entity<PaymentInfo>().HasIndex(p => p.ExpirationDate);
        }
    }
}
