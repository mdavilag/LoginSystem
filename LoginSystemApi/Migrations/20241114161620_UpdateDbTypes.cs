using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "VARCHAR(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "VARCHAR(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar[20]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "text",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "varchar[20]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");
        }
    }
}
