using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPP.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntityGameToProductAndSomeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Games_GameId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserCreatedId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Games_GameId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_User_UserCreatedId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Games_GameId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "MyUsers");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "MyRoles");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Warehouses",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_GameId",
                table: "Warehouses",
                newName: "IX_Warehouses_ProductId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Posts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_GameId",
                table: "Posts",
                newName: "IX_Posts_ProductId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_GameId",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "MyUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "MyUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MyUsers",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "MyUsers",
                newName: "IX_MyUsers_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUsers",
                table: "MyUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyRoles",
                table: "MyRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_MyRoles_RoleId",
                table: "MyUsers",
                column: "RoleId",
                principalTable: "MyRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MyUsers_UserCreatedId",
                table: "Orders",
                column: "UserCreatedId",
                principalTable: "MyUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_MyUsers_UserCreatedId",
                table: "Posts",
                column: "UserCreatedId",
                principalTable: "MyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Products_ProductId",
                table: "Posts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Products_ProductId",
                table: "Warehouses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_MyRoles_RoleId",
                table: "MyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MyUsers_UserCreatedId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_MyUsers_UserCreatedId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Products_ProductId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Products_ProductId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUsers",
                table: "MyUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyRoles",
                table: "MyRoles");

            migrationBuilder.RenameTable(
                name: "MyUsers",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "MyRoles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Warehouses",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_ProductId",
                table: "Warehouses",
                newName: "IX_Warehouses_GameId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Posts",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ProductId",
                table: "Posts",
                newName: "IX_Posts_GameId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                newName: "IX_Orders_GameId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_MyUsers_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Games_GameId",
                table: "Orders",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserCreatedId",
                table: "Orders",
                column: "UserCreatedId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Games_GameId",
                table: "Posts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_User_UserCreatedId",
                table: "Posts",
                column: "UserCreatedId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Games_GameId",
                table: "Warehouses",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
