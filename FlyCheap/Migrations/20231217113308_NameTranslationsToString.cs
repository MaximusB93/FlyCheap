using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlyCheap.Migrations
{
    /// <inheritdoc />
    public partial class NameTranslationsToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airlines_NameTranslations_name_translationsen",
                table: "Airlines");

            migrationBuilder.DropForeignKey(
                name: "FK_Airports_NameTranslations_name_translationsen",
                table: "Airports");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Cases_casesda",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Coordinates_coordinateslat",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_NameTranslations_name_translationsen",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Cases_casesda",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_casesda",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.DropIndex(
                name: "IX_Cities_casesda",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_coordinateslat",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_name_translationsen",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Airports_name_translationsen",
                table: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Airlines_name_translationsen",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "casesda",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "casesda",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "coordinateslat",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "name_translationsen",
                table: "Airports");

            migrationBuilder.RenameColumn(
                name: "name_translationsen",
                table: "Cities",
                newName: "name_translations");

            migrationBuilder.RenameColumn(
                name: "name_translationsen",
                table: "Airlines",
                newName: "name_translations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "NameTranslations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "casesId",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Coordinates",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cases",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "name_translations",
                table: "Airports",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_casesId",
                table: "Countries",
                column: "casesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Cases_casesId",
                table: "Countries",
                column: "casesId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Cases_casesId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Coordinates_coordinatesId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Cases_casesId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_casesId",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.DropIndex(
                name: "IX_Cities_casesId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_coordinatesId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NameTranslations");

            migrationBuilder.DropColumn(
                name: "casesId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "casesId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "coordinatesId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "name_translations",
                table: "Airports");

            migrationBuilder.RenameColumn(
                name: "name_translations",
                table: "Cities",
                newName: "name_translationsen");

            migrationBuilder.RenameColumn(
                name: "name_translations",
                table: "Airlines",
                newName: "name_translationsen");

            migrationBuilder.AddColumn<string>(
                name: "casesda",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "casesda",
                table: "Cities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "coordinateslat",
                table: "Cities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "name_translationsen",
                table: "Airports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "lat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "da");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_casesda",
                table: "Countries",
                column: "casesda");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_casesda",
                table: "Cities",
                column: "casesda");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_coordinateslat",
                table: "Cities",
                column: "coordinateslat");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_name_translationsen",
                table: "Cities",
                column: "name_translationsen");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_name_translationsen",
                table: "Airports",
                column: "name_translationsen");

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_name_translationsen",
                table: "Airlines",
                column: "name_translationsen");

            migrationBuilder.AddForeignKey(
                name: "FK_Airlines_NameTranslations_name_translationsen",
                table: "Airlines",
                column: "name_translationsen",
                principalTable: "NameTranslations",
                principalColumn: "en",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_NameTranslations_name_translationsen",
                table: "Airports",
                column: "name_translationsen",
                principalTable: "NameTranslations",
                principalColumn: "en",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Cases_casesda",
                table: "Cities",
                column: "casesda",
                principalTable: "Cases",
                principalColumn: "da",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Coordinates_coordinateslat",
                table: "Cities",
                column: "coordinateslat",
                principalTable: "Coordinates",
                principalColumn: "lat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_NameTranslations_name_translationsen",
                table: "Cities",
                column: "name_translationsen",
                principalTable: "NameTranslations",
                principalColumn: "en",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Cases_casesda",
                table: "Countries",
                column: "casesda",
                principalTable: "Cases",
                principalColumn: "da",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
