using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipiApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToiletsAndPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toilets_People_PersonPublicId",
                table: "Toilets");

            migrationBuilder.DropForeignKey(
                name: "FK_Toilets_People_PersonPublicId1",
                table: "Toilets");

            migrationBuilder.DropIndex(
                name: "IX_Toilets_PersonPublicId",
                table: "Toilets");

            migrationBuilder.DropIndex(
                name: "IX_Toilets_PersonPublicId1",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "PersonPublicId",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "PersonPublicId1",
                table: "Toilets");

            migrationBuilder.AddColumn<string>(
                name: "ToiletRecordId",
                table: "People",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToiletRecordId1",
                table: "People",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ToiletRecordId",
                table: "People",
                column: "ToiletRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ToiletRecordId1",
                table: "People",
                column: "ToiletRecordId1");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Toilets_ToiletRecordId",
                table: "People",
                column: "ToiletRecordId",
                principalTable: "Toilets",
                principalColumn: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Toilets_ToiletRecordId1",
                table: "People",
                column: "ToiletRecordId1",
                principalTable: "Toilets",
                principalColumn: "RecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Toilets_ToiletRecordId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Toilets_ToiletRecordId1",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ToiletRecordId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ToiletRecordId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ToiletRecordId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ToiletRecordId1",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonPublicId",
                table: "Toilets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonPublicId1",
                table: "Toilets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toilets_PersonPublicId",
                table: "Toilets",
                column: "PersonPublicId");

            migrationBuilder.CreateIndex(
                name: "IX_Toilets_PersonPublicId1",
                table: "Toilets",
                column: "PersonPublicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Toilets_People_PersonPublicId",
                table: "Toilets",
                column: "PersonPublicId",
                principalTable: "People",
                principalColumn: "PublicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toilets_People_PersonPublicId1",
                table: "Toilets",
                column: "PersonPublicId1",
                principalTable: "People",
                principalColumn: "PublicId");
        }
    }
}
