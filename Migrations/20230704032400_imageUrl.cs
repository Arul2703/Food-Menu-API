using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMenuApi.Migrations
{
    /// <inheritdoc />
    public partial class imageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "FoodItems",
                newName: "imageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "FoodItems",
                newName: "Image");
        }
    }
}
