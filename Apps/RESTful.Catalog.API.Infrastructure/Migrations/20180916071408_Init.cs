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
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureFileName = table.Column<string>(nullable: true),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    CatalogTypeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId1",
                        column: x => x.CatalogTypeId1,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Catalog",
                columns: new[] { "Id", "CatalogTypeId", "CatalogTypeId1", "Description", "Name", "PictureFileName", "Price" },
                values: new object[,]
                {
                    { 2, 1, null, ".NET Black & White Mug", ".NET Black & White Mug", "2.png", 8.50m },
                    { 9, 1, null, "Cup<T> White Mug", "Cup<T> White Mug", "9.png", 12m },
                    { 1, 2, null, ".NET Bot Black Hoodie", ".NET Bot Black Hoodie", "1.png", 19.5m },
                    { 3, 2, null, "Prism White T-Shirt", "Prism White T-Shirt", "3.png", 12m },
                    { 4, 2, null, ".NET Foundation T-shirt", ".NET Foundation T-shirt", "4.png", 12m },
                    { 6, 2, null, ".NET Blue Hoodie", ".NET Blue Hoodie", "6.png", 12m },
                    { 7, 2, null, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt", "7.png", 12m },
                    { 8, 2, null, "Kudu Purple Hoodie", "Kudu Purple Hoodie", "8.png", 8.5m },
                    { 12, 2, null, "Prism White TShirt", "Prism White TShirt", "12.png", 12m },
                    { 5, 3, null, "Roslyn Red Sheet", "Roslyn Red Sheet", "5.png", 8.5m },
                    { 10, 3, null, ".NET Foundation Sheet", ".NET Foundation Sheet", "10.png", 12m },
                    { 11, 3, null, "Cup<T> Sheet", "Cup<T> Sheet", "11.png", 8.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId1",
                table: "Catalog",
                column: "CatalogTypeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_type_hilo");
        }
    }
}
