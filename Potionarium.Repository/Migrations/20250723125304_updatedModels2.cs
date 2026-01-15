using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Potionarium.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFromApi",
                table: "Potion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFromApi",
                table: "Potion");
        }
    }
}
