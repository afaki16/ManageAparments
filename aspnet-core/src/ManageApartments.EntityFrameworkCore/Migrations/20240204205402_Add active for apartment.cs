using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageApartments.Migrations
{
    /// <inheritdoc />
    public partial class Addactiveforapartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Apartments",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Apartments");
        }
    }
}
