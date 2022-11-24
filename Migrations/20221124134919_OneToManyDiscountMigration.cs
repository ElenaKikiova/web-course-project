using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Migrations
{
    public partial class OneToManyDiscountMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_DiscountId",
                table: "Shoes",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Discounts_DiscountId",
                table: "Shoes",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Discounts_DiscountId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_DiscountId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Shoes");
        }
    }
}
