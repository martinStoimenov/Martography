using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ImageToTestimonials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ImageId",
                table: "Testimonials",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Images_ImageId",
                table: "Testimonials",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Images_ImageId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_ImageId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Testimonials");
        }
    }
}
