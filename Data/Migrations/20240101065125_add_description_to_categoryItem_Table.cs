using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTree_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_description_to_categoryItem_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CategoryItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CategoryItem");
        }
    }
}
