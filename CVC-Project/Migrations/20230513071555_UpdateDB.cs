using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypicalCategories",
                columns: table => new
                {
                    TypicalCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypicalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypicalImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypicalCategories", x => x.TypicalCategoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypicalCategories");
        }
    }
}
