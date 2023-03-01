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
            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Item",
                newName: "condition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "condition",
                table: "Item",
                newName: "picture");
        }
    }
}
