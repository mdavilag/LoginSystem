using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleFksRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
