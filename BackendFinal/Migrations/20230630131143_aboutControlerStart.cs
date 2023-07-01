using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFinal.Migrations
{
    public partial class aboutControlerStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutImgUrl",
                table: "Bios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeneralInformation",
                table: "Bios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AboutSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutSections_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AboutSections_AspNetUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AboutSections_AspNetUsers_UpdateByUserId",
                        column: x => x.UpdateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSections");

            migrationBuilder.DropColumn(
                name: "AboutImgUrl",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "GeneralInformation",
                table: "Bios");
        }
    }
}
