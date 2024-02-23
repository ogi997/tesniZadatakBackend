using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class TEST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StavkaFakture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    NazivArtikla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IznosBezPdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostoRabata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rabat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IznosSaRabatomBezPdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ukupno = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaFakture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZaglavljeFakture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IznosBezPdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostoRabata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rabat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IznosSaRabatomBezPdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ukupno = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaglavljeFakture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Zaglavlja_Fakture = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Stavke_Fakture = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KorisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fakture_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fakture_KorisnikId",
                table: "Fakture",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fakture");

            migrationBuilder.DropTable(
                name: "StavkaFakture");

            migrationBuilder.DropTable(
                name: "ZaglavljeFakture");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
