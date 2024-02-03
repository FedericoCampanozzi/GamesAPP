using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPP.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_MyRoles_RoleId",
                table: "MyUsers");

            migrationBuilder.DropTable(
                name: "MyRoles");

            migrationBuilder.DropIndex(
                name: "IX_MyUsers_RoleId",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "MyUsers");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MyUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "MyUsers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "MyUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MyRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyUsers_RoleId",
                table: "MyUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_MyRoles_RoleId",
                table: "MyUsers",
                column: "RoleId",
                principalTable: "MyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
