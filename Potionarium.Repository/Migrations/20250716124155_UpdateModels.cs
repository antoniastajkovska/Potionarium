using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Potionarium.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Inventory_InventoryID",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Potion_PotionId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellInSpellBook_SpellBook_SpellBookId",
                table: "SpellInSpellBook");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellInSpellBook_Spell_SpellId",
                table: "SpellInSpellBook");

            migrationBuilder.DropIndex(
                name: "IX_SpellBook_UserId",
                table: "SpellBook");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_UserId",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellInSpellBook",
                table: "SpellInSpellBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItem",
                table: "InventoryItem");

            migrationBuilder.RenameTable(
                name: "SpellInSpellBook",
                newName: "SpellInSpellBooks");

            migrationBuilder.RenameTable(
                name: "InventoryItem",
                newName: "InventoryItems");

            migrationBuilder.RenameIndex(
                name: "IX_SpellInSpellBook_SpellId",
                table: "SpellInSpellBooks",
                newName: "IX_SpellInSpellBooks_SpellId");

            migrationBuilder.RenameIndex(
                name: "IX_SpellInSpellBook_SpellBookId",
                table: "SpellInSpellBooks",
                newName: "IX_SpellInSpellBooks_SpellBookId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItem_PotionId",
                table: "InventoryItems",
                newName: "IX_InventoryItems_PotionId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItem_InventoryID",
                table: "InventoryItems",
                newName: "IX_InventoryItems_InventoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellInSpellBooks",
                table: "SpellInSpellBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpellBook_UserId",
                table: "SpellBook",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UserId",
                table: "Inventory",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Inventory_InventoryID",
                table: "InventoryItems",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Potion_PotionId",
                table: "InventoryItems",
                column: "PotionId",
                principalTable: "Potion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellInSpellBooks_SpellBook_SpellBookId",
                table: "SpellInSpellBooks",
                column: "SpellBookId",
                principalTable: "SpellBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellInSpellBooks_Spell_SpellId",
                table: "SpellInSpellBooks",
                column: "SpellId",
                principalTable: "Spell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Inventory_InventoryID",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Potion_PotionId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellInSpellBooks_SpellBook_SpellBookId",
                table: "SpellInSpellBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellInSpellBooks_Spell_SpellId",
                table: "SpellInSpellBooks");

            migrationBuilder.DropIndex(
                name: "IX_SpellBook_UserId",
                table: "SpellBook");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_UserId",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellInSpellBooks",
                table: "SpellInSpellBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems");

            migrationBuilder.RenameTable(
                name: "SpellInSpellBooks",
                newName: "SpellInSpellBook");

            migrationBuilder.RenameTable(
                name: "InventoryItems",
                newName: "InventoryItem");

            migrationBuilder.RenameIndex(
                name: "IX_SpellInSpellBooks_SpellId",
                table: "SpellInSpellBook",
                newName: "IX_SpellInSpellBook_SpellId");

            migrationBuilder.RenameIndex(
                name: "IX_SpellInSpellBooks_SpellBookId",
                table: "SpellInSpellBook",
                newName: "IX_SpellInSpellBook_SpellBookId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_PotionId",
                table: "InventoryItem",
                newName: "IX_InventoryItem_PotionId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_InventoryID",
                table: "InventoryItem",
                newName: "IX_InventoryItem_InventoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellInSpellBook",
                table: "SpellInSpellBook",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItem",
                table: "InventoryItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpellBook_UserId",
                table: "SpellBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UserId",
                table: "Inventory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Inventory_InventoryID",
                table: "InventoryItem",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Potion_PotionId",
                table: "InventoryItem",
                column: "PotionId",
                principalTable: "Potion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellInSpellBook_SpellBook_SpellBookId",
                table: "SpellInSpellBook",
                column: "SpellBookId",
                principalTable: "SpellBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellInSpellBook_Spell_SpellId",
                table: "SpellInSpellBook",
                column: "SpellId",
                principalTable: "Spell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
