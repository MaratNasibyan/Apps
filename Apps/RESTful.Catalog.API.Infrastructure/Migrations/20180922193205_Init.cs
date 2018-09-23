using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTful.Catalog.API.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureFileName = table.Column<string>(nullable: true),
                    CatalogTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Mug" },
                    { 2, "T-Shirt" },
                    { 3, "Sheet" },
                    { 4, "USB Memory Stick" }
                });

            migrationBuilder.InsertData(
                table: "CatalogItem",
                columns: new[] { "Id", "CatalogTypeId", "Description", "Name", "PictureFileName", "Price" },
                values: new object[,]
                {
                    { 2, 1, ".NET Black & White Mug", ".NET Black & White Mug", "2.png", 8.50m },
                    { 9, 1, "Cup<T> White Mug", "Cup<T> White Mug", "9.png", 12m },
                    { 1, 2, ".NET Bot Black Hoodie", ".NET Bot Black Hoodie", "1.png", 19.5m },
                    { 3, 2, "Prism White T-Shirt", "Prism White T-Shirt", "3.png", 12m },
                    { 4, 2, ".NET Foundation T-shirt", ".NET Foundation T-shirt", "4.png", 12m },
                    { 6, 2, ".NET Blue Hoodie", ".NET Blue Hoodie", "6.png", 12m },
                    { 7, 2, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt", "7.png", 12m },
                    { 8, 2, "Kudu Purple Hoodie", "Kudu Purple Hoodie", "8.png", 8.5m },
                    { 12, 2, "Prism White TShirt", "Prism White TShirt", "12.png", 12m },
                    { 5, 3, "Roslyn Red Sheet", "Roslyn Red Sheet", "5.png", 8.5m },
                    { 10, 3, ".NET Foundation Sheet", ".NET Foundation Sheet", "10.png", 12m },
                    { 11, 3, "Cup<T> Sheet", "Cup<T> Sheet", "11.png", 8.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                table: "CatalogItem",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItem");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_type_hilo");
        }
    }
}
