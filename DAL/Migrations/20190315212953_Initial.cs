using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_categories",
                columns: table => new
                {
                    cln_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cln_name = table.Column<string>(nullable: true),
                    cln_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_categories", x => x.cln_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_products",
                columns: table => new
                {
                    cln_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cln_category_id = table.Column<int>(nullable: false),
                    cln_name = table.Column<string>(nullable: true),
                    cln_quantity = table.Column<int>(nullable: false),
                    cln_price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_products", x => x.cln_id);
                    table.ForeignKey(
                        name: "FK_tbl_products_tbl_categories_cln_category_id",
                        column: x => x.cln_category_id,
                        principalTable: "tbl_categories",
                        principalColumn: "cln_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_categories",
                columns: new[] { "cln_id", "cln_code", "cln_name" },
                values: new object[] { 1, "BICYC", "Bicycling" });

            migrationBuilder.InsertData(
                table: "tbl_categories",
                columns: new[] { "cln_id", "cln_code", "cln_name" },
                values: new object[] { 2, "MARAR", "Martial arts" });

            migrationBuilder.InsertData(
                table: "tbl_categories",
                columns: new[] { "cln_id", "cln_code", "cln_name" },
                values: new object[] { 3, "FITSS", "Fitness" });

            migrationBuilder.InsertData(
                table: "tbl_products",
                columns: new[] { "cln_id", "cln_category_id", "cln_name", "cln_price", "cln_quantity" },
                values: new object[,]
                {
                    { 1, 1, "Brakes", 50m, 10 },
                    { 2, 1, "Drivetrain", 82.3m, 4 },
                    { 3, 1, "Fork", 100.25m, 36 },
                    { 4, 2, "Kimono", 15.6m, 200 },
                    { 5, 2, "Boxing gloves", 5.5m, 512 },
                    { 6, 2, "Boxing helmet", 20m, 123 },
                    { 7, 3, "Fitness mat", 12.32m, 56 },
                    { 8, 3, "Hoop", 12.5m, 312 },
                    { 9, 3, "Fitball", 6.3m, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_cln_category_id",
                table: "tbl_products",
                column: "cln_category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_products");

            migrationBuilder.DropTable(
                name: "tbl_categories");
        }
    }
}
