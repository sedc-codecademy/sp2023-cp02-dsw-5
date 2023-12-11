using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipfinity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixedTypoInProductPercentageProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountPercenrage",
                table: "Products",
                newName: "DiscountPercentage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "Products",
                newName: "DiscountPercenrage");
        }
    }
}
