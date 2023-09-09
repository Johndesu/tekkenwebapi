using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekkenPortugal.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_Userid",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tags_Tagsid",
                table: "ArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_Usersid",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Usersid",
                table: "RoleUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_Usersid",
                table: "RoleUser",
                newName: "IX_RoleUser_UsersId");

            migrationBuilder.RenameColumn(
                name: "Tagsid",
                table: "ArticleTag",
                newName: "TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_Tagsid",
                table: "ArticleTag",
                newName: "IX_ArticleTag_TagsId");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Articles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_Userid",
                table: "Articles",
                newName: "IX_Articles_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tags_TagsId",
                table: "ArticleTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tags_TagsId",
                table: "ArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "RoleUser",
                newName: "Usersid");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                newName: "IX_RoleUser_Usersid");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "ArticleTag",
                newName: "Tagsid");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_TagsId",
                table: "ArticleTag",
                newName: "IX_ArticleTag_Tagsid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Articles",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                newName: "IX_Articles_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_Userid",
                table: "Articles",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tags_Tagsid",
                table: "ArticleTag",
                column: "Tagsid",
                principalTable: "Tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_Usersid",
                table: "RoleUser",
                column: "Usersid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
