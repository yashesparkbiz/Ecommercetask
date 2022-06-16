using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommercetask.Data.Migrations
{
    public partial class adduseridinProducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_user_id",
                table: "Product",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_user_id",
                table: "Product",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_user_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_user_id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Product");
        }
    }
}
