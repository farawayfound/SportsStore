using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "A 1-Person Boat", "Kayak", 275m },
                    { 2, "Watersports", "Protective AND Fashionable", "Life Jacket", 48.95m },
                    { 3, "Soccer", "FIFA Approved Size And Weight", "Soccer Ball", 34.95m },
                    { 4, "Soccer", "Like The Pros", "Corner Flags", 19.50m },
                    { 5, "Running", "A New Level Of Comfort", "Running Shoes", 89.95m },
                    { 6, "Football", "Broncos Logo", "Football", 59.95m },
                    { 7, "Baseball", "Official Size & Weight", "Baseball", 9.95m },
                    { 8, "Baseball", "Genuine Leather", "Baseball Glove", 94.95m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
