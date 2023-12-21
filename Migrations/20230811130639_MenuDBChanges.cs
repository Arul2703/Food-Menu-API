using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMenuApi.Migrations
{
    /// <inheritdoc />
    public partial class MenuDBChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodCategories_FoodCategoryName",
                table: "FoodItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "FoodItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FoodItems",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsVegan",
                table: "FoodItems",
                newName: "isVegan");

            migrationBuilder.RenameColumn(
                name: "FoodCategoryName",
                table: "FoodItems",
                newName: "FoodCategoryname");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "FoodItems",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "FoodItems",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "FoodItems",
                newName: "calories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FoodItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItems_FoodCategoryName",
                table: "FoodItems",
                newName: "IX_FoodItems_FoodCategoryname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FoodCategories",
                newName: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodCategories_FoodCategoryname",
                table: "FoodItems",
                column: "FoodCategoryname",
                principalTable: "FoodCategories",
                principalColumn: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodCategories_FoodCategoryname",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "FoodItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "FoodItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isVegan",
                table: "FoodItems",
                newName: "IsVegan");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "FoodItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "FoodItems",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "calories",
                table: "FoodItems",
                newName: "Calories");

            migrationBuilder.RenameColumn(
                name: "FoodCategoryname",
                table: "FoodItems",
                newName: "FoodCategoryName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FoodItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItems_FoodCategoryname",
                table: "FoodItems",
                newName: "IX_FoodItems_FoodCategoryName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "FoodCategories",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodCategories_FoodCategoryName",
                table: "FoodItems",
                column: "FoodCategoryName",
                principalTable: "FoodCategories",
                principalColumn: "Name");
        }
    }
}
