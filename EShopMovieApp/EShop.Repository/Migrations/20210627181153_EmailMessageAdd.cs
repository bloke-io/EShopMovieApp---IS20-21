using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Repository.Migrations
{
    public partial class EmailMessageAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmailMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MailTo = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrders",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.DropIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                columns: new[] { "TicketId", "OrderId" });
        }
    }
}
