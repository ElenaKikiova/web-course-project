using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Migrations
{
    public partial class ManyToManyShoeShoeSupplierMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoeSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoe_ShoeSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(type: "int", nullable: false),
                    ShoeSupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe_ShoeSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoe_ShoeSuppliers_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoe_ShoeSuppliers_ShoeSuppliers_ShoeSupplierId",
                        column: x => x.ShoeSupplierId,
                        principalTable: "ShoeSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_ShoeSuppliers_ShoeId",
                table: "Shoe_ShoeSuppliers",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_ShoeSuppliers_ShoeSupplierId",
                table: "Shoe_ShoeSuppliers",
                column: "ShoeSupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoe_ShoeSuppliers");

            migrationBuilder.DropTable(
                name: "ShoeSuppliers");
        }
    }
}
