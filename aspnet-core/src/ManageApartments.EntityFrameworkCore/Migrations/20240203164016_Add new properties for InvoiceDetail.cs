using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageApartments.Migrations
{
    /// <inheritdoc />
    public partial class AddnewpropertiesforInvoiceDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPaymentDate",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaymentDate",
                table: "InvoiceDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
