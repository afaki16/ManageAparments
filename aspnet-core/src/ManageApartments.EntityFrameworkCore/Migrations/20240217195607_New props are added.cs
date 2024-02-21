using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageApartments.Migrations
{
    /// <inheritdoc />
    public partial class Newpropsareadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Deposit",
                table: "Hirers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Hirers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Hirers");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Hirers");
        }
    }
}
