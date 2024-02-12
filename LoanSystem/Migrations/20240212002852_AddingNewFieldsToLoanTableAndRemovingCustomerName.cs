using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewFieldsToLoanTableAndRemovingCustomerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Loans");

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Loans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Loans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Loans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Loans",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
