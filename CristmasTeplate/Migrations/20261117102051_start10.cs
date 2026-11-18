using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CristmasTeplate.Migrations
{
    /// <inheritdoc />
    public partial class start10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Banners",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "LabelName",
                table: "Banners",
                newName: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Banners",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Banners",
                newName: "LabelName");
        }
    }
}
