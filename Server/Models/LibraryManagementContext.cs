using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.Models
{
    public partial class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext()
        {
        }

        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LibBook> LibBooks { get; set; } = null!;
        public virtual DbSet<LibBookManagementCard> LibBookManagementCards { get; set; } = null!;
        public virtual DbSet<LibCallCard> LibCallCards { get; set; } = null!;
        public virtual DbSet<LibMember> LibMembers { get; set; } = null!;
        public virtual DbSet<LibMembership> LibMemberships { get; set; } = null!;
        public virtual DbSet<LibUser> LibUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=localhost");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibBook>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK_Book");

                entity.ToTable("Lib_Book");

                entity.HasIndex(e => e.Id, "UQ__Lib_Book__3214EC266CFD1D7E")
                    .IsUnique();

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PublishedDate).HasColumnType("date");

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.Property(e => e.ReceivedDate).HasColumnType("date");

                entity.Property(e => e.Receiver)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.LibBooks)
                    .HasForeignKey(d => d.Receiver)
                    .HasConstraintName("FK_B_U");
            });

            modelBuilder.Entity<LibBookManagementCard>(entity =>
            {
                entity.ToTable("Lib_BookModificationCard");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Creator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.LibBookManagementCards)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_BMC_U");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.LibBookManagementCards)
                    .HasForeignKey(d => d.Isbn)
                    .HasConstraintName("FK_BMC_B");
            });

            modelBuilder.Entity<LibCallCard>(entity =>
            {
                entity.ToTable("Lib_CallCard");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Creator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentDate).HasColumnType("date");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.MembershipId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MembershipID")
                    .IsFixedLength();

                entity.Property(e => e.MembershipName).HasMaxLength(50);

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.LibCallCards)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_CC_U");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.LibCallCards)
                    .HasForeignKey(d => d.Isbn)
                    .HasConstraintName("FK_CC_B");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.LibCallCards)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK_CC_MS");
            });

            modelBuilder.Entity<LibMember>(entity =>
            {
                entity.ToTable("Lib_Member");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.MembershipId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MembershipID")
                    .IsFixedLength();

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.LibMembers)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK_M_M");
            });

            modelBuilder.Entity<LibMembership>(entity =>
            {
                entity.HasKey(e => e.MembershipId)
                    .HasName("PK_Membership");

                entity.ToTable("Lib_Membership");

                entity.HasIndex(e => e.Id, "UQ__Lib_Memb__3214EC2620FBD211")
                    .IsUnique();

                entity.Property(e => e.MembershipId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MembershipID")
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Creator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.LibMemberships)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_MS_U");
            });

            modelBuilder.Entity<LibUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.ToTable("Lib_User");

                entity.HasIndex(e => e.Id, "UQ__Lib_User__3214EC2683C2742C")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
