using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Data.Migrations
{
    /// <inheritdoc />
    public partial class finalsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "itemDetails",
                table: "Item",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemDetails",
                table: "Item");
        }
    }
}
