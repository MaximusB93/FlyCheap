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
                name: "Cases",
                columns: table => new
                {
                    da = table.Column<string>(type: "text", nullable: false),
                    pr = table.Column<string>(type: "text", nullable: false),
                    ro = table.Column<string>(type: "text", nullable: false),
                    su = table.Column<string>(type: "text", nullable: false),
                    tv = table.Column<string>(type: "text", nullable: false),
                    vi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.da);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    lat = table.Column<float>(type: "real", nullable: false),
                    lon = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.lat);
                });

            migrationBuilder.CreateTable(
                name: "NameTranslations",
                columns: table => new
                {
                    en = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameTranslations", x => x.en);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    is_lowcost = table.Column<string>(type: "text", nullable: false),
                    name_translationsen = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.code);
                    table.ForeignKey(
                        name: "FK_Airlines_NameTranslations_name_translationsen",
                        column: x => x.name_translationsen,
                        principalTable: "NameTranslations",
                        principalColumn: "en",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    time_zone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    iata_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    flightable = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false),
                    name_translationsen = table.Column<string>(type: "text", nullable: false),
                    lat = table.Column<float>(type: "real", nullable: false),
                    lon = table.Column<float>(type: "real", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_NameTranslations_name_translationsen",
                        column: x => x.name_translationsen,
                        principalTable: "NameTranslations",
                        principalColumn: "en",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    time_zone = table.Column<string>(type: "text", nullable: false),
                    coordinateslat = table.Column<float>(type: "real", nullable: false),
                    name_translationsen = table.Column<string>(type: "text", nullable: false),
                    casesda = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.code);
                    table.ForeignKey(
                        name: "FK_Cities_Cases_casesda",
                        column: x => x.casesda,
                        principalTable: "Cases",
                        principalColumn: "da",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_Coordinates_coordinateslat",
                        column: x => x.coordinateslat,
                        principalTable: "Coordinates",
                        principalColumn: "lat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_NameTranslations_name_translationsen",
                        column: x => x.name_translationsen,
                        principalTable: "NameTranslations",
                        principalColumn: "en",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    name_translationsen = table.Column<string>(type: "text", nullable: false),
                    casesda = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.code);
                    table.ForeignKey(
                        name: "FK_Countries_Cases_casesda",
                        column: x => x.casesda,
                        principalTable: "Cases",
                        principalColumn: "da",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_NameTranslations_name_translationsen",
                        column: x => x.name_translationsen,
                        principalTable: "NameTranslations",
                        principalColumn: "en",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_name_translationsen",
                table: "Airlines",
                column: "name_translationsen");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_name_translationsen",
                table: "Airports",
                column: "name_translationsen");

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
                name: "IX_Countries_casesda",
                table: "Countries",
                column: "casesda");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_name_translationsen",
                table: "Countries",
                column: "name_translationsen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "NameTranslations");
        }
    }
}
