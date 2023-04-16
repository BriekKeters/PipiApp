using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipiApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class onlyIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_People_PersonPublicId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Toilets_ToiletRecordId",
                table: "Comments");

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

            migrationBuilder.DropIndex(
                name: "IX_Comments_PersonPublicId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ToiletRecordId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ToiletRecordId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ToiletRecordId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonPublicId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ToiletRecordId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Toilets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DislikedToilets",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LikedToilets",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Toilets");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DislikedToilets",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LikedToilets",
                table: "People");

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

            migrationBuilder.AddColumn<Guid>(
                name: "PersonPublicId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToiletRecordId",
                table: "Comments",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PersonPublicId",
                table: "Comments",
                column: "PersonPublicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ToiletRecordId",
                table: "Comments",
                column: "ToiletRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_People_PersonPublicId",
                table: "Comments",
                column: "PersonPublicId",
                principalTable: "People",
                principalColumn: "PublicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Toilets_ToiletRecordId",
                table: "Comments",
                column: "ToiletRecordId",
                principalTable: "Toilets",
                principalColumn: "RecordId");

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
    }
}
