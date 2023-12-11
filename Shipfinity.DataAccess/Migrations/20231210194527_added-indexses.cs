using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipfinity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedindexses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "PaymentInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "PaymentInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "PaymentInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_CardNumber",
                table: "PaymentInfos",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_ExpirationDate",
                table: "PaymentInfos",
                column: "ExpirationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentInfos_CardNumber",
                table: "PaymentInfos");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfos_ExpirationDate",
                table: "PaymentInfos");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "PaymentInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "PaymentInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "PaymentInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
