using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Projects_ProjectId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProjectId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Testimonials",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Testimonials",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "Images",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Images",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "BlogPosts",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "BlogPosts",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Testimonials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "BlogPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_IsDeleted",
                table: "Testimonials",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsDeleted",
                table: "Projects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsDeleted",
                table: "Images",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectId",
                table: "Images",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_IsDeleted",
                table: "BlogPosts",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Projects_ProjectId",
                table: "Images",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Projects_ProjectId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_IsDeleted",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Projects_IsDeleted",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Images_IsDeleted",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProjectId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_IsDeleted",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Testimonials",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Testimonials",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Images",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Images",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "BlogPosts",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "BlogPosts",
                newName: "CreatedDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectId1",
                table: "Images",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Projects_ProjectId1",
                table: "Images",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
