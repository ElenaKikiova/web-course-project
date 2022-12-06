using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Migrations
{
    public partial class Brands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_BrandId",
                table: "Shoes",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Brands_BrandId",
                table: "Shoes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Brands_BrandId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_BrandId",
                table: "Shoes");
        }
    }
}
