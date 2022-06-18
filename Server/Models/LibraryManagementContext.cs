using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext()
        {
        }

        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LibBook> LibBooks { get; set; } = null!;
        public virtual DbSet<LibCallCard> LibCallCards { get; set; } = null!;
        public virtual DbSet<LibFineCard> LibFineCards { get; set; } = null!;
        public virtual DbSet<LibBookAuditCard> LibBookAuditCards { get; set; } = null!;
        public virtual DbSet<LibMember> LibMembers { get; set; } = null!;
        public virtual DbSet<LibMembership> LibMemberships { get; set; } = null!;
        public virtual DbSet<LibUser> LibUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=libmproddb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibBook>()
                        .HasOne(x => x.Receiver)
                        .WithMany(y => y.CreatedLibBooks)
                        .HasForeignKey(z => z.ReceiverId);

            modelBuilder.Entity<LibBook>()
                        .HasOne(x => x.Modifier)
                        .WithMany(y => y.ModifiedLibBooks)
                        .HasForeignKey(z => z.ModifierId);

            modelBuilder.Entity<LibMember>()
                        .HasOne(x => x.Membership)
                        .WithOne(y => y.Member)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<LibMember>()
                        .HasOne(x => x.Creator)
                        .WithMany(y => y.CreatedLibMembers)
                        .HasForeignKey(z => z.CreatorId);

            modelBuilder.Entity<LibMember>()
                       .HasOne(x => x.Modifier)
                       .WithMany(y => y.ModifiedLibMembers)
                       .HasForeignKey(z => z.ModifierId);

            modelBuilder.Entity<LibMembership>()
                        .HasOne(x => x.Member)
                        .WithOne(y => y.Membership)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LibMembership>()
                       .HasOne(x => x.Creator)
                       .WithMany(y => y.CreatedLibMemberships)
                       .HasForeignKey(z => z.CreatorId);

            modelBuilder.Entity<LibMembership>()
                       .HasOne(x => x.Modifier)
                       .WithMany(y => y.ModifiedLibMemberships)
                       .HasForeignKey(z => z.ModifierId);
        }
    }
}
