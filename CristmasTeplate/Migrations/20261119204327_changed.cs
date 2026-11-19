using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CristmasTeplate.Migrations
{
    /// <inheritdoc />
    public partial class changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Categories_CategoryId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "MainImg",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Baskets",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_CategoryId",
                table: "Baskets",
                newName: "IX_Baskets_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductId",
                table: "Baskets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductId",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Baskets",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                newName: "IX_Baskets_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImg",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Baskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Categories_CategoryId",
                table: "Baskets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
