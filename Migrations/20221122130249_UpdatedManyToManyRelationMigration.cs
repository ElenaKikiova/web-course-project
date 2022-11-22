using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Migrations
{
    public partial class UpdatedManyToManyRelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_ShoeSuppliers_Shoes_ShoeId",
                table: "Shoe_ShoeSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_ShoeSuppliers_ShoeSuppliers_ShoeSupplierId",
                table: "Shoe_ShoeSuppliers");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_ShoeSuppliers_Shoes_ShoeId",
                table: "Shoe_ShoeSuppliers",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_ShoeSuppliers_ShoeSuppliers_ShoeSupplierId",
                table: "Shoe_ShoeSuppliers",
                column: "ShoeSupplierId",
                principalTable: "ShoeSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_ShoeSuppliers_Shoes_ShoeId",
                table: "Shoe_ShoeSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_ShoeSuppliers_ShoeSuppliers_ShoeSupplierId",
                table: "Shoe_ShoeSuppliers");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_ShoeSuppliers_Shoes_ShoeId",
                table: "Shoe_ShoeSuppliers",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_ShoeSuppliers_ShoeSuppliers_ShoeSupplierId",
                table: "Shoe_ShoeSuppliers",
                column: "ShoeSupplierId",
                principalTable: "ShoeSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
