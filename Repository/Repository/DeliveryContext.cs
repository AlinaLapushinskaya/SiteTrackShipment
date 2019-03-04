using System;
using System.Collections.Generic;

using Date;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext()
        {
        }

        public DeliveryContext(DbContextOptions<DeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressBook> AddressBook { get; set; }
        public virtual DbSet<Carrier> Carrier { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Delivery;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<AddressBook>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.StreetLine1).HasMaxLength(255);

                entity.Property(e => e.StreetLine2).HasMaxLength(255);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AddressBook)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__AddressBo__IdUse__398D8EEE");
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.Logotip).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.NameRole).HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.HasOne(d => d.IdCarrierNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCarrier)
                    .HasConstraintName("FK__Users__IdCarrier__37A5467C");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCompany)
                    .HasConstraintName("FK__Users__IdCompany__38996AB5");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Users__IdRole__36B12243");
            });
        }
    }
}
