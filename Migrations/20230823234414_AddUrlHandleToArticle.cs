using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekkenPortugal.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlHandleToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Categories_Categoriesid",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_Rolesid",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "Rolesid",
                table: "RoleUser",
                newName: "RolesId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Categoriesid",
                table: "ArticleCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_Categoriesid",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_CategoriesId");

            migrationBuilder.AddColumn<string>(
                name: "UrlHandle",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Categories_CategoriesId",
                table: "ArticleCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Categories_CategoriesId",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "UrlHandle",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "RoleUser",
                newName: "Rolesid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "ArticleCategory",
                newName: "Categoriesid");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_CategoriesId",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_Categoriesid");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Categories_Categoriesid",
                table: "ArticleCategory",
                column: "Categoriesid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_Rolesid",
                table: "RoleUser",
                column: "Rolesid",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
