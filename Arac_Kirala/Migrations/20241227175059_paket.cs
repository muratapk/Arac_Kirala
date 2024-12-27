using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arac_Kirala.Migrations
{
    /// <inheritdoc />
    public partial class paket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.MarkaId);
                });

            migrationBuilder.CreateTable(
                name: "Modellers",
                columns: table => new
                {
                    ModellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModellerAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modellers", x => x.ModellerId);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusterAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriKul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriSifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyons",
                columns: table => new
                {
                    RezervasyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlisTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlisSaati = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirakTarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirakSaati = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyons", x => x.RezervasyonId);
                });

            migrationBuilder.CreateTable(
                name: "Vites",
                columns: table => new
                {
                    VitesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VitesAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vites", x => x.VitesId);
                });

            migrationBuilder.CreateTable(
                name: "Yakit",
                columns: table => new
                {
                    YakitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YakitAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yakit", x => x.YakitId);
                });

            migrationBuilder.CreateTable(
                name: "Araclars",
                columns: table => new
                {
                    AracId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitesId = table.Column<int>(type: "int", nullable: true),
                    YakitId = table.Column<int>(type: "int", nullable: true),
                    ModellerId = table.Column<int>(type: "int", nullable: true),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    Depozito = table.Column<int>(type: "int", nullable: true),
                    KmLimit = table.Column<int>(type: "int", nullable: true),
                    Koltuk = table.Column<int>(type: "int", nullable: true),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkalarMarkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclars", x => x.AracId);
                    table.ForeignKey(
                        name: "FK_Araclars_Markalar_MarkalarMarkaId",
                        column: x => x.MarkalarMarkaId,
                        principalTable: "Markalar",
                        principalColumn: "MarkaId");
                    table.ForeignKey(
                        name: "FK_Araclars_Modellers_ModellerId",
                        column: x => x.ModellerId,
                        principalTable: "Modellers",
                        principalColumn: "ModellerId");
                    table.ForeignKey(
                        name: "FK_Araclars_Vites_VitesId",
                        column: x => x.VitesId,
                        principalTable: "Vites",
                        principalColumn: "VitesId");
                    table.ForeignKey(
                        name: "FK_Araclars_Yakit_YakitId",
                        column: x => x.YakitId,
                        principalTable: "Yakit",
                        principalColumn: "YakitId");
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AracId = table.Column<int>(type: "int", nullable: false),
                    AraclarAracId = table.Column<int>(type: "int", nullable: true),
                    MusterilerMusteriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.OdemeId);
                    table.ForeignKey(
                        name: "FK_Odemeler_Araclars_AraclarAracId",
                        column: x => x.AraclarAracId,
                        principalTable: "Araclars",
                        principalColumn: "AracId");
                    table.ForeignKey(
                        name: "FK_Odemeler_Musteriler_MusterilerMusteriId",
                        column: x => x.MusterilerMusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriId");
                    table.ForeignKey(
                        name: "FK_Odemeler_Rezervasyons_RezervasyonId",
                        column: x => x.RezervasyonId,
                        principalTable: "Rezervasyons",
                        principalColumn: "RezervasyonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclars_MarkalarMarkaId",
                table: "Araclars",
                column: "MarkalarMarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Araclars_ModellerId",
                table: "Araclars",
                column: "ModellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Araclars_VitesId",
                table: "Araclars",
                column: "VitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Araclars_YakitId",
                table: "Araclars",
                column: "YakitId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_AraclarAracId",
                table: "Odemeler",
                column: "AraclarAracId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_MusterilerMusteriId",
                table: "Odemeler",
                column: "MusterilerMusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_RezervasyonId",
                table: "Odemeler",
                column: "RezervasyonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "Araclars");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Rezervasyons");

            migrationBuilder.DropTable(
                name: "Markalar");

            migrationBuilder.DropTable(
                name: "Modellers");

            migrationBuilder.DropTable(
                name: "Vites");

            migrationBuilder.DropTable(
                name: "Yakit");
        }
    }
}
