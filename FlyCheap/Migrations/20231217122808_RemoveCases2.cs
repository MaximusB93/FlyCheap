using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyCheap.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCases2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Cases_casesId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_casesId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "casesId",
                table: "Countries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "casesId",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_casesId",
                table: "Countries",
                column: "casesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Cases_casesId",
                table: "Countries",
                column: "casesId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
