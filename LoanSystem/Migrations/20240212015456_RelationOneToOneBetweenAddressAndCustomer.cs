using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanSystem.Migrations
{
    /// <inheritdoc />
    public partial class RelationOneToOneBetweenAddressAndCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerID",
                table: "Addresses",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Addresses");
        }
    }
}
