using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipiApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preference = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PublicId);
                });

            migrationBuilder.CreateTable(
                name: "Toilets",
                columns: table => new
                {
                    RecordId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Toilets = table.Column<int>(type: "int", nullable: false),
                    Urinals = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OpenHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    OpenMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonPublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonPublicId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toilets", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Toilets_People_PersonPublicId",
                        column: x => x.PersonPublicId,
                        principalTable: "People",
                        principalColumn: "PublicId");
                    table.ForeignKey(
                        name: "FK_Toilets_People_PersonPublicId1",
                        column: x => x.PersonPublicId1,
                        principalTable: "People",
                        principalColumn: "PublicId");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentedToiletId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PersonPublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToiletRecordId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_People_PersonPublicId",
                        column: x => x.PersonPublicId,
                        principalTable: "People",
                        principalColumn: "PublicId");
                    table.ForeignKey(
                        name: "FK_Comments_Toilets_ToiletRecordId",
                        column: x => x.ToiletRecordId,
                        principalTable: "Toilets",
                        principalColumn: "RecordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PersonPublicId",
                table: "Comments",
                column: "PersonPublicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ToiletRecordId",
                table: "Comments",
                column: "ToiletRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Toilets_PersonPublicId",
                table: "Toilets",
                column: "PersonPublicId");

            migrationBuilder.CreateIndex(
                name: "IX_Toilets_PersonPublicId1",
                table: "Toilets",
                column: "PersonPublicId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Toilets");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
