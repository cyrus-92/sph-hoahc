using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPH.Entity.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    PasswordHashed = table.Column<string>(maxLength: 150, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                table: "Users",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifierId",
                table: "Users",
                column: "ModifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
