using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreProject.Migrations
{
    /// <inheritdoc />
    public partial class deneme11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sifre",
                table: "Admins",
                type: "Varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sifre",
                table: "Admins",
                type: "Varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(10)");
        }
    }
}
