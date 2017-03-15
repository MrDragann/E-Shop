using DataModel.Models;
using System.Data.Entity;

/// <summary>
/// Содержит сущности и логику предметной области;  создает хранилище с помощью инфраструктуры Entity Framework
/// </summary>
namespace DataModel
{
    /// <summary>
    /// Класс контекста, который ассоциирует модель с базой данных. 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DataContext : DbContext
    {
        public DataContext()
        : base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<AccountConfirmation> AccountConfirmations { get; set; }

        public DbSet<StatusUser> StatusUsers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<StatusOrder> StatusOrders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                Property(p => p.RegistrationDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<User>().
                Property(p => p.LastLoginDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<Product>().
                Property(p => p.DateAdd)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            //modelBuilder.Entity<UserProfile>()
            //    .HasRequired(e => e.UserId)
            //    .HasKey(t => t.UserId)
            //    .HasForeignKey("dbo.Users", t => t.UserId)
            //    .Index(t => t.UserId);
        }

        
    }
}
