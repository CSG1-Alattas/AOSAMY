using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AOSAMY.Models
{
    public partial class DbAOSAMYContext : DbContext
    {
        public DbAOSAMYContext()
        {
        }

        public DbAOSAMYContext(DbContextOptions<DbAOSAMYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<TypeProduct> TypeProducts { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=DbAOSAMY;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.TypeProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeProductid)
                    .HasConstraintName("FK_Product_TypeProduct");

                entity.HasOne(d => d.UserLog)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserLogid)
                    .HasConstraintName("FK_Product_UserInfo");
            });

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.ToTable("TypeProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Img).HasColumnName("img");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("UserInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.ScendName).HasMaxLength(50);

                entity.Property(e => e.Specialty).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
