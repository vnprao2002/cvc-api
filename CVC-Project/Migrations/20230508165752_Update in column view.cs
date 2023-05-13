using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class Updateincolumnview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "View",
                table: "SubCategories");
        }
    }
}
