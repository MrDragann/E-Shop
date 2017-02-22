using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
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
        }

        
    }
}
