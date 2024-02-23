using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakture_Korisnici_KorisnikId",
                table: "Fakture");

            migrationBuilder.DropTable(
                name: "ZaglavljeFakture");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici");

            migrationBuilder.DropIndex(
                name: "IX_Fakture_KorisnikId",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Id_Stavke_Fakture",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Id_Zaglavlja_Fakture",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Fakture");

            migrationBuilder.AddColumn<Guid>(
                name: "FakturaId",
                table: "StavkaFakture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Korisnici",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Broj",
                table: "Fakture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Fakture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "IznosBezPdv",
                table: "Fakture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IznosSaRabatomBezPdv",
                table: "Fakture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Partner",
                table: "Fakture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Pdv",
                table: "Fakture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PostoRabata",
                table: "Fakture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rabat",
                table: "Fakture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Ukupno",
                table: "Fakture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_StavkaFakture_FakturaId",
                table: "StavkaFakture",
                column: "FakturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Lastname",
                table: "Korisnici",
                column: "Lastname",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkaFakture_Fakture_FakturaId",
                table: "StavkaFakture",
                column: "FakturaId",
                principalTable: "Fakture",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkaFakture_Fakture_FakturaId",
                table: "StavkaFakture");

            migrationBuilder.DropIndex(
                name: "IX_StavkaFakture_FakturaId",
                table: "StavkaFakture");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_Lastname",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "FakturaId",
                table: "StavkaFakture");

            migrationBuilder.DropColumn(
                name: "Broj",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "IznosBezPdv",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "IznosSaRabatomBezPdv",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Partner",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Pdv",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "PostoRabata",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Rabat",
                table: "Fakture");

            migrationBuilder.DropColumn(
                name: "Ukupno",
                table: "Fakture");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Korisnici",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Stavke_Fakture",
                table: "Fakture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Zaglavlja_Fakture",
                table: "Fakture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "KorisnikId",
                table: "Fakture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZaglavljeFakture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IznosBezPdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IznosSaRabatomBezPdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pdv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostoRabata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rabat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ukupno = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaglavljeFakture", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fakture_KorisnikId",
                table: "Fakture",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fakture_Korisnici_KorisnikId",
                table: "Fakture",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id");
        }
    }
}
