using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPP.Migrations
{
    /// <inheritdoc />
    public partial class FixSomeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserCreatedId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserCreatedId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserCreatedId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "UserCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_UserCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserCreatedId",
                table: "Orders",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
