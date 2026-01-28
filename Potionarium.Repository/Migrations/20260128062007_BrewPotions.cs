using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Potionarium.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class BrewPotions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedPotions");

            migrationBuilder.CreateTable(
                name: "BrewedPotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BrewedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewedPotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewedPotions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrewedPotions_Potion_PotionId",
                        column: x => x.PotionId,
                        principalTable: "Potion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrewedPotions_PotionId",
                table: "BrewedPotions",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewedPotions_UserId",
                table: "BrewedPotions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewedPotions");

            migrationBuilder.CreateTable(
                name: "PurchasedPotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedPotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedPotions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedPotions_Potion_PotionId",
                        column: x => x.PotionId,
                        principalTable: "Potion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedPotions_PotionId",
                table: "PurchasedPotions",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedPotions_UserId",
                table: "PurchasedPotions",
                column: "UserId");
        }
    }
}
