using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardPortal.Persistence.Migrations
{
    public partial class Init007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactTypes_TypeId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_TypeId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Contacts",
                newName: "ContactTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                table: "Contacts",
                newName: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TypeId",
                table: "Contacts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactTypes_TypeId",
                table: "Contacts",
                column: "TypeId",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
