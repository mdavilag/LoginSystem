using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIdsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_RolesId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_UsersId",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserRole",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRole",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                newName: "IX_UserRole_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_RoleId",
                table: "UserRole",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_UserId",
                table: "UserRole",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_UserId",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserRole",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "UserRole",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UsersId",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_RolesId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_UsersId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
