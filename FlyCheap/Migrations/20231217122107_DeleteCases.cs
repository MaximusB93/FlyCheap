using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlyCheap.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Cases_casesId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Coordinates_coordinatesId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NameTranslations",
                table: "NameTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Cities_casesId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_coordinatesId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "casesId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "coordinatesId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "NameTranslations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<double>(
                name: "lat",
                table: "Cities",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "lon",
                table: "Cities",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NameTranslations",
                table: "NameTranslations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NameTranslations",
                table: "NameTranslations");

            migrationBuilder.DropColumn(
                name: "lat",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "lon",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "NameTranslations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "casesId",
                table: "Cities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "coordinatesId",
                table: "Cities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NameTranslations",
                table: "NameTranslations",
                column: "en");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_casesId",
                table: "Cities",
                column: "casesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_coordinatesId",
                table: "Cities",
                column: "coordinatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Cases_casesId",
                table: "Cities",
                column: "casesId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Coordinates_coordinatesId",
                table: "Cities",
                column: "coordinatesId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
