using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CristmasTeplate.Migrations
{
    /// <inheritdoc />
    public partial class start6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LabelName",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabelName",
                table: "Banners");
        }
    }
}
