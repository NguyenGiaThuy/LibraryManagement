using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LibBooks",
                columns: table => new
                {
                    BookId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibBooks", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_LibBooks_LibUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LibBooks_LibUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LibMemberships",
                columns: table => new
                {
                    MembershipId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SocialId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MembershipType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibMemberships", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_LibMemberships_LibUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LibMemberships_LibUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LibBookAuditCards",
                columns: table => new
                {
                    BookAuditCardId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibBookAuditCards", x => x.BookAuditCardId);
                    table.ForeignKey(
                        name: "FK_LibBookAuditCards_LibBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "LibBooks",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibBookAuditCards_LibUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LibCallCards",
                columns: table => new
                {
                    CallCardId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MembershipId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCallCards", x => x.CallCardId);
                    table.ForeignKey(
                        name: "FK_LibCallCards_LibBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "LibBooks",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCallCards_LibMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "LibMemberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibCallCards_LibUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LibMembers",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SocialId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibMembers", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_LibMembers_LibMemberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "LibMemberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibMembers_LibUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LibMembers_LibUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LibFineCards",
                columns: table => new
                {
                    FineCardId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Arrears = table.Column<int>(type: "int", nullable: true),
                    DaysInArrears = table.Column<int>(type: "int", nullable: true),
                    CallCardId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibFineCards", x => x.FineCardId);
                    table.ForeignKey(
                        name: "FK_LibFineCards_LibCallCards_CallCardId",
                        column: x => x.CallCardId,
                        principalTable: "LibCallCards",
                        principalColumn: "CallCardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibFineCards_LibUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "LibUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibBookAuditCards_BookId",
                table: "LibBookAuditCards",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibBookAuditCards_CreatorId",
                table: "LibBookAuditCards",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibBooks_ModifierId",
                table: "LibBooks",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_LibBooks_ReceiverId",
                table: "LibBooks",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCallCards_BookId",
                table: "LibCallCards",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCallCards_CreatorId",
                table: "LibCallCards",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibCallCards_MembershipId",
                table: "LibCallCards",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_LibFineCards_CallCardId",
                table: "LibFineCards",
                column: "CallCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LibFineCards_CreatorId",
                table: "LibFineCards",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibMembers_CreatorId",
                table: "LibMembers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibMembers_MembershipId",
                table: "LibMembers",
                column: "MembershipId",
                unique: true,
                filter: "[MembershipId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LibMembers_ModifierId",
                table: "LibMembers",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_LibMemberships_CreatorId",
                table: "LibMemberships",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibMemberships_ModifierId",
                table: "LibMemberships",
                column: "ModifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibBookAuditCards");

            migrationBuilder.DropTable(
                name: "LibFineCards");

            migrationBuilder.DropTable(
                name: "LibMembers");

            migrationBuilder.DropTable(
                name: "LibCallCards");

            migrationBuilder.DropTable(
                name: "LibBooks");

            migrationBuilder.DropTable(
                name: "LibMemberships");

            migrationBuilder.DropTable(
                name: "LibUsers");
        }
    }
}
