using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyCheap.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNameTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_translations",
                table: "Cities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name_translations",
                table: "Cities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
