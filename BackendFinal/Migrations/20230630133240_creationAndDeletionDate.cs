using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFinal.Migrations
{
    public partial class creationAndDeletionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSections_AspNetUsers_CreatedByUserId",
                table: "AboutSections");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSections_AspNetUsers_DeletedByUserId",
                table: "AboutSections");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSections_AspNetUsers_UpdateByUserId",
                table: "AboutSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Banners_AspNetUsers_CreatedByUserId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Banners_AspNetUsers_DeletedByUserId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Banners_AspNetUsers_UpdateByUserId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_AspNetUsers_CreatedByUserId",
                table: "Sliders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_AspNetUsers_DeletedByUserId",
                table: "Sliders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_AspNetUsers_UpdateByUserId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_CreatedByUserId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_DeletedByUserId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_UpdateByUserId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Banners_CreatedByUserId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_DeletedByUserId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_UpdateByUserId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_AboutSections_CreatedByUserId",
                table: "AboutSections");

            migrationBuilder.DropIndex(
                name: "IX_AboutSections_DeletedByUserId",
                table: "AboutSections");

            migrationBuilder.DropIndex(
                name: "IX_AboutSections_UpdateByUserId",
                table: "AboutSections");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "AboutSections");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AboutSections");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "AboutSections");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AboutSections");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "AboutSections");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AboutSections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Sliders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedByUserId",
                table: "Sliders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Sliders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Banners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedByUserId",
                table: "Banners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Banners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Banners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "AboutSections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AboutSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedByUserId",
                table: "AboutSections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AboutSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "AboutSections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AboutSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_CreatedByUserId",
                table: "Sliders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_DeletedByUserId",
                table: "Sliders",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_UpdateByUserId",
                table: "Sliders",
                column: "UpdateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CreatedByUserId",
                table: "Banners",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_DeletedByUserId",
                table: "Banners",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_UpdateByUserId",
                table: "Banners",
                column: "UpdateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSections_CreatedByUserId",
                table: "AboutSections",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSections_DeletedByUserId",
                table: "AboutSections",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSections_UpdateByUserId",
                table: "AboutSections",
                column: "UpdateByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSections_AspNetUsers_CreatedByUserId",
                table: "AboutSections",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSections_AspNetUsers_DeletedByUserId",
                table: "AboutSections",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSections_AspNetUsers_UpdateByUserId",
                table: "AboutSections",
                column: "UpdateByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_AspNetUsers_CreatedByUserId",
                table: "Banners",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_AspNetUsers_DeletedByUserId",
                table: "Banners",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_AspNetUsers_UpdateByUserId",
                table: "Banners",
                column: "UpdateByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_AspNetUsers_CreatedByUserId",
                table: "Sliders",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_AspNetUsers_DeletedByUserId",
                table: "Sliders",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_AspNetUsers_UpdateByUserId",
                table: "Sliders",
                column: "UpdateByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
