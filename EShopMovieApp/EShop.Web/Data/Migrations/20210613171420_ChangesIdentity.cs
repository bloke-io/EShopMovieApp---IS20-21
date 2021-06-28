using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Web.Data.Migrations
{
    public partial class ChangesIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EShopApplicationUserId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TicketInShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EShopApplicationUserId",
                table: "Tickets",
                column: "EShopApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_EShopApplicationUserId",
                table: "Tickets",
                column: "EShopApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_EShopApplicationUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EShopApplicationUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EShopApplicationUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TicketInShoppingCarts");
        }
    }
}
