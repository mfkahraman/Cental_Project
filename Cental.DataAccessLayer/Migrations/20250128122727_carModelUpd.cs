using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cental.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class carModelUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GearType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearType",
                table: "Cars");
        }
    }
}
