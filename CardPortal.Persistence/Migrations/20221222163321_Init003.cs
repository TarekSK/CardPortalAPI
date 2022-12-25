using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardPortal.Persistence.Migrations
{
    public partial class Init003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Vendors_VendorId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_VendorId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VendorId",
                table: "Transactions",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Vendors_VendorId",
                table: "Transactions",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
