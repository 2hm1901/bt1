using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bt1.Migrations
{
    /// <inheritdoc />
    public partial class updateJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoriesId",
                table: "Jobs",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoriesId",
                table: "Jobs",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoriesId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoriesId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Jobs");
        }
    }
}
