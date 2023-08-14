using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekkenPortugal.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlHandleToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlHandle",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlHandle",
                table: "Categories");
        }
    }
}
