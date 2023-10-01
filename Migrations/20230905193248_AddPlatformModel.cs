using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekkenPortugal.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatformModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tags_Tagsid",
                table: "ArticleTag");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Tagsid",
                table: "ArticleTag",
                newName: "TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_Tagsid",
                table: "ArticleTag",
                newName: "IX_ArticleTag_TagsId");

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tags_TagsId",
                table: "ArticleTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tags_TagsId",
                table: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "ArticleTag",
                newName: "Tagsid");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_TagsId",
                table: "ArticleTag",
                newName: "IX_ArticleTag_Tagsid");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tags_Tagsid",
                table: "ArticleTag",
                column: "Tagsid",
                principalTable: "Tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
