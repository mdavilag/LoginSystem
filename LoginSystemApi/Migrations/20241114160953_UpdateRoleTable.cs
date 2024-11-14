using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "varchar[20]",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
