using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyCheap.Migrations
{
    /// <inheritdoc />
    public partial class NameTranslationRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_NameTranslations_name_translationsen",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_name_translationsen",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "name_translationsen",
                table: "Countries",
                newName: "name_translations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name_translations",
                table: "Countries",
                newName: "name_translationsen");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_name_translationsen",
                table: "Countries",
                column: "name_translationsen");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_NameTranslations_name_translationsen",
                table: "Countries",
                column: "name_translationsen",
                principalTable: "NameTranslations",
                principalColumn: "en",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
