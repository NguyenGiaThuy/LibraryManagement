using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class AddModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lib_User",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Mobile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Education = table.Column<int>(type: "int", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Lib_Book",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Receiver = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_B_U",
                        column: x => x.Receiver,
                        principalTable: "Lib_User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Lib_Membership",
                columns: table => new
                {
                    MembershipID = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArrearAmount = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    DaysInArrear = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    MembershipType = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.MembershipID);
                    table.ForeignKey(
                        name: "FK_MS_U",
                        column: x => x.Creator,
                        principalTable: "Lib_User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Lib_BookModificationCard",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    Creator = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_BookModificationCard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BMC_B",
                        column: x => x.ISBN,
                        principalTable: "Lib_Book",
                        principalColumn: "ISBN");
                    table.ForeignKey(
                        name: "FK_BMC_U",
                        column: x => x.Creator,
                        principalTable: "Lib_User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Lib_CallCard",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    MembershipID = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    MembershipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArrearAmount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CurrentDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    Creator = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_CallCard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CC_B",
                        column: x => x.ISBN,
                        principalTable: "Lib_Book",
                        principalColumn: "ISBN");
                    table.ForeignKey(
                        name: "FK_CC_MS",
                        column: x => x.MembershipID,
                        principalTable: "Lib_Membership",
                        principalColumn: "MembershipID");
                    table.ForeignKey(
                        name: "FK_CC_U",
                        column: x => x.Creator,
                        principalTable: "Lib_User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Lib_Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    MembershipID = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib_Member", x => x.ID);
                    table.ForeignKey(
                        name: "FK_M_M",
                        column: x => x.MembershipID,
                        principalTable: "Lib_Membership",
                        principalColumn: "MembershipID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lib_Book_Receiver",
                table: "Lib_Book",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "UQ__Lib_Book__3214EC266CFD1D7E",
                table: "Lib_Book",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lib_BookModificationCard_Creator",
                table: "Lib_BookModificationCard",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Lib_BookModificationCard_ISBN",
                table: "Lib_BookModificationCard",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Lib_CallCard_Creator",
                table: "Lib_CallCard",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Lib_CallCard_ISBN",
                table: "Lib_CallCard",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Lib_CallCard_MembershipID",
                table: "Lib_CallCard",
                column: "MembershipID");

            migrationBuilder.CreateIndex(
                name: "IX_Lib_Member_MembershipID",
                table: "Lib_Member",
                column: "MembershipID");

            migrationBuilder.CreateIndex(
                name: "IX_Lib_Membership_Creator",
                table: "Lib_Membership",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "UQ__Lib_Memb__3214EC2620FBD211",
                table: "Lib_Membership",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Lib_User__3214EC2683C2742C",
                table: "Lib_User",
                column: "ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lib_BookModificationCard");

            migrationBuilder.DropTable(
                name: "Lib_CallCard");

            migrationBuilder.DropTable(
                name: "Lib_Member");

            migrationBuilder.DropTable(
                name: "Lib_Book");

            migrationBuilder.DropTable(
                name: "Lib_Membership");

            migrationBuilder.DropTable(
                name: "Lib_User");
        }
    }
}
