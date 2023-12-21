using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMenuApi.Migrations
{
    /// <inheritdoc />
    public partial class isingallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInGallery",
                table: "FoodItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInGallery",
                table: "FoodItems");
        }
    }
}
