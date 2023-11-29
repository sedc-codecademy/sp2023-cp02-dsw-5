using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipfinity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addednewslettersubsribers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ProductReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NewsletterSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEmailSentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterSubscribers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_CustomerId",
                table: "ProductReviews",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Customers_CustomerId",
                table: "ProductReviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Customers_CustomerId",
                table: "ProductReviews");

            migrationBuilder.DropTable(
                name: "NewsletterSubscribers");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_CustomerId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ProductReviews");
        }
    }
}
