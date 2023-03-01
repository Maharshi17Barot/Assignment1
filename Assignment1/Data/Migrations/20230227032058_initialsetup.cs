using System.Drawing;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    itemName = table.Column<string>(type: "TEXT", nullable: false),
                    itemCost = table.Column<float>(type: "REAL", nullable: false),
                    itemDetails = table.Column<string>(type: "Text", nullable: false),
                    startDate = table.Column<DateTime>(type: "REAL", nullable: false), 
                    endDate = table.Column<DateTime>(type: "REAL", nullable: false),
                    category = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
