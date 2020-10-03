using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    EngineId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLanguage",
                columns: table => new
                {
                    ProgramLanguageId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLanguage", x => x.ProgramLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "LanguageSearch",
                columns: table => new
                {
                    LanguageSearchId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    EngineId = table.Column<Guid>(nullable: false),
                    ProgramLanguageId = table.Column<Guid>(nullable: false),
                    CurrentSearchs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageSearch", x => x.LanguageSearchId);
                    table.ForeignKey(
                        name: "FK_LanguageSearch_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageSearch_ProgramLanguage_ProgramLanguageId",
                        column: x => x.ProgramLanguageId,
                        principalTable: "ProgramLanguage",
                        principalColumn: "ProgramLanguageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSearch_EngineId",
                table: "LanguageSearch",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSearch_ProgramLanguageId",
                table: "LanguageSearch",
                column: "ProgramLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageSearch");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "ProgramLanguage");
        }
    }
}
