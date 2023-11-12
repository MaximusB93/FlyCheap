using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlyCheap.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataCoordinates",
                columns: table => new
                {
                    CoordinatesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lat = table.Column<float>(type: "real", nullable: false),
                    lon = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCoordinates", x => x.CoordinatesId);
                });

            migrationBuilder.CreateTable(
                name: "DataNameTranslations",
                columns: table => new
                {
                    NameTranslationsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    en = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataNameTranslations", x => x.NameTranslationsId);
                });

            migrationBuilder.CreateTable(
                name: "DataAirports",
                columns: table => new
                {
                    AirportsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_code = table.Column<string>(type: "text", nullable: false),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    time_zone = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    iata_type = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    flightable = table.Column<bool>(type: "boolean", nullable: false),
                    NameTranslationsId = table.Column<int>(type: "integer", nullable: false),
                    CoordinatesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAirports", x => x.AirportsId);
                    table.ForeignKey(
                        name: "FK_DataAirports_DataCoordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "DataCoordinates",
                        principalColumn: "CoordinatesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataAirports_DataNameTranslations_NameTranslationsId",
                        column: x => x.NameTranslationsId,
                        principalTable: "DataNameTranslations",
                        principalColumn: "NameTranslationsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataAirports_CoordinatesId",
                table: "DataAirports",
                column: "CoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_DataAirports_NameTranslationsId",
                table: "DataAirports",
                column: "NameTranslationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataAirports");

            migrationBuilder.DropTable(
                name: "DataCoordinates");

            migrationBuilder.DropTable(
                name: "DataNameTranslations");
        }
    }
}
