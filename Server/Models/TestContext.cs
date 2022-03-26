using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=localhost");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Ibsn)
                    .HasName("PK__libm_Boo__9833F42F70F25EB7");

                entity.ToTable("libm_Book");

                entity.HasIndex(e => e.Id, "UQ__libm_Boo__3213E83ECAD329FB")
                    .IsUnique();

                entity.Property(e => e.Ibsn)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ibsn");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__libm_Use__F3DBC573E75C26CA");

                entity.ToTable("libm_User");

                entity.HasIndex(e => e.Id, "UQ__libm_Use__3213E83E24100D64")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
