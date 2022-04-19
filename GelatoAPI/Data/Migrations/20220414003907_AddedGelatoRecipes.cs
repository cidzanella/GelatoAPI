using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GelatoAPI.Data.Migrations
{
    public partial class AddedGelatoRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GelatoRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    BaseTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseInGrams = table.Column<int>(type: "INTEGER", nullable: false),
                    PastaAId = table.Column<int>(type: "INTEGER", nullable: true),
                    PastaAInGrams = table.Column<int>(type: "INTEGER", nullable: true),
                    PastaBId = table.Column<int>(type: "INTEGER", nullable: true),
                    PastaBInGrams = table.Column<int>(type: "INTEGER", nullable: true),
                    VariegatoAId = table.Column<int>(type: "INTEGER", nullable: true),
                    VariegatoAInGrams = table.Column<int>(type: "INTEGER", nullable: true),
                    VariegatoBId = table.Column<int>(type: "INTEGER", nullable: true),
                    VariegatoBInGrams = table.Column<int>(type: "INTEGER", nullable: true),
                    ExtractionLayers = table.Column<int>(type: "INTEGER", nullable: false),
                    MinimumStockLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    GelatoCost = table.Column<double>(type: "REAL", nullable: true),
                    GelatoCostDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GelatoRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GelatoRecipes_BaseTypes_BaseTypeId",
                        column: x => x.BaseTypeId,
                        principalTable: "BaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GelatoRecipes_BaseTypeId",
                table: "GelatoRecipes",
                column: "BaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GelatoRecipes_PastaAId",
                table: "GelatoRecipes",
                column: "PastaAId");

            migrationBuilder.CreateIndex(
                name: "IX_GelatoRecipes_PastaBId",
                table: "GelatoRecipes",
                column: "PastaBId");

            migrationBuilder.CreateIndex(
                name: "IX_GelatoRecipes_VariegatoAId",
                table: "GelatoRecipes",
                column: "VariegatoAId");

            migrationBuilder.CreateIndex(
                name: "IX_GelatoRecipes_VariegatoBId",
                table: "GelatoRecipes",
                column: "VariegatoBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GelatoRecipes");
        }
    }
}
