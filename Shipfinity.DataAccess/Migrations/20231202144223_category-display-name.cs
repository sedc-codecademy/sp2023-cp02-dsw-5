using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipfinity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class categorydisplayname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Categories");
        }
    }
}
