using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkaFakture_Fakture_FakturaId",
                table: "StavkaFakture");

            migrationBuilder.AlterColumn<Guid>(
                name: "FakturaId",
                table: "StavkaFakture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkaFakture_Fakture_FakturaId",
                table: "StavkaFakture",
                column: "FakturaId",
                principalTable: "Fakture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkaFakture_Fakture_FakturaId",
                table: "StavkaFakture");

            migrationBuilder.AlterColumn<Guid>(
                name: "FakturaId",
                table: "StavkaFakture",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StavkaFakture_Fakture_FakturaId",
                table: "StavkaFakture",
                column: "FakturaId",
                principalTable: "Fakture",
                principalColumn: "Id");
        }
    }
}
