﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Models;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(LibraryManagementContext))]
    [Migration("20220531182408_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Server.Models.LibBook", b =>
                {
                    b.Property<string>("BookId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("LibBooks");
                });

            modelBuilder.Entity("Server.Models.LibBookAuditCard", b =>
                {
                    b.Property<string>("BookAuditCardId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("Reason")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("BookAuditCardId");

                    b.HasIndex("BookId");

                    b.HasIndex("CreatorId");

                    b.ToTable("LibBookAuditCards");
                });

            modelBuilder.Entity("Server.Models.LibCallCard", b =>
                {
                    b.Property<string>("CallCardId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MembershipId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("CallCardId");

                    b.HasIndex("BookId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("MembershipId");

                    b.ToTable("LibCallCards");
                });

            modelBuilder.Entity("Server.Models.LibFineCard", b =>
                {
                    b.Property<string>("FineCardId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("Arrears")
                        .HasColumnType("int");

                    b.Property<string>("CallCardId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("DaysInArrears")
                        .HasColumnType("int");

                    b.Property<int?>("Reason")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("FineCardId");

                    b.HasIndex("CallCardId");

                    b.HasIndex("CreatorId");

                    b.ToTable("LibFineCards");
                });

            modelBuilder.Entity("Server.Models.LibMember", b =>
                {
                    b.Property<string>("MemberId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MembershipId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("MemberId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("MembershipId")
                        .IsUnique()
                        .HasFilter("[MembershipId] IS NOT NULL");

                    b.HasIndex("ModifierId");

                    b.ToTable("LibMembers");
                });

            modelBuilder.Entity("Server.Models.LibMembership", b =>
                {
                    b.Property<string>("MembershipId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MembershipType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifierId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SocialId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("LibMemberships");
                });

            modelBuilder.Entity("Server.Models.LibUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Department")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Education")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("LibUsers");
                });

            modelBuilder.Entity("Server.Models.LibBook", b =>
                {
                    b.HasOne("Server.Models.LibUser", "Modifier")
                        .WithMany("ModifiedLibBooks")
                        .HasForeignKey("ModifierId");

                    b.HasOne("Server.Models.LibUser", "Receiver")
                        .WithMany("CreatedLibBooks")
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Modifier");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Server.Models.LibBookAuditCard", b =>
                {
                    b.HasOne("Server.Models.LibBook", "Book")
                        .WithMany("LibBookAuditCards")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.LibUser", "Creator")
                        .WithMany("CreatedLibBookAuditCards")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Book");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Server.Models.LibCallCard", b =>
                {
                    b.HasOne("Server.Models.LibBook", "Book")
                        .WithMany("LibCallCards")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.LibUser", "Creator")
                        .WithMany("CreatedLibCallCards")
                        .HasForeignKey("CreatorId");

                    b.HasOne("Server.Models.LibMembership", "Membership")
                        .WithMany("LibCallCards")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Creator");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("Server.Models.LibFineCard", b =>
                {
                    b.HasOne("Server.Models.LibCallCard", "CallCard")
                        .WithMany()
                        .HasForeignKey("CallCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.LibUser", "Creator")
                        .WithMany("CreatedLibFineCards")
                        .HasForeignKey("CreatorId");

                    b.Navigation("CallCard");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Server.Models.LibMember", b =>
                {
                    b.HasOne("Server.Models.LibUser", "Creator")
                        .WithMany("CreatedLibMembers")
                        .HasForeignKey("CreatorId");

                    b.HasOne("Server.Models.LibMembership", "Membership")
                        .WithOne("Member")
                        .HasForeignKey("Server.Models.LibMember", "MembershipId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Models.LibUser", "Modifier")
                        .WithMany("ModifiedLibMembers")
                        .HasForeignKey("ModifierId");

                    b.Navigation("Creator");

                    b.Navigation("Membership");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("Server.Models.LibMembership", b =>
                {
                    b.HasOne("Server.Models.LibUser", "Creator")
                        .WithMany("CreatedLibMemberships")
                        .HasForeignKey("CreatorId");

                    b.HasOne("Server.Models.LibUser", "Modifier")
                        .WithMany("ModifiedLibMemberships")
                        .HasForeignKey("ModifierId");

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("Server.Models.LibBook", b =>
                {
                    b.Navigation("LibBookAuditCards");

                    b.Navigation("LibCallCards");
                });

            modelBuilder.Entity("Server.Models.LibMembership", b =>
                {
                    b.Navigation("LibCallCards");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Server.Models.LibUser", b =>
                {
                    b.Navigation("CreatedLibBookAuditCards");

                    b.Navigation("CreatedLibBooks");

                    b.Navigation("CreatedLibCallCards");

                    b.Navigation("CreatedLibFineCards");

                    b.Navigation("CreatedLibMembers");

                    b.Navigation("CreatedLibMemberships");

                    b.Navigation("ModifiedLibBooks");

                    b.Navigation("ModifiedLibMembers");

                    b.Navigation("ModifiedLibMemberships");
                });
#pragma warning restore 612, 618
        }
    }
}
