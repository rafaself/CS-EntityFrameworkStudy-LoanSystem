using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelationOneToManyBetweenLoansAndCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Loans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Loans");
        }
    }
}
