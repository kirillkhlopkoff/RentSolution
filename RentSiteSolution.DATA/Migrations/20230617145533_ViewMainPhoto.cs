using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentSiteSolution.DATA.Migrations
{
    /// <inheritdoc />
    public partial class ViewMainPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Photos_MainPhotoId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_MainPhotoId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "MainPhotoId",
                table: "Apartments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainPhotoId",
                table: "Apartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_MainPhotoId",
                table: "Apartments",
                column: "MainPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Photos_MainPhotoId",
                table: "Apartments",
                column: "MainPhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}
