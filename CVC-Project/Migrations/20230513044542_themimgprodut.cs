using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class themimgprodut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImg",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImg",
                table: "Product");
        }
    }
}
