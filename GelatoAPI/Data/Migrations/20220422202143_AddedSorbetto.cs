using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GelatoAPI.Data.Migrations
{
    public partial class AddedSorbetto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SorbettoRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SorbettoTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RawMaterialId = table.Column<int>(type: "INTEGER", nullable: false),
                    GramsPerKg = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SorbettoRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SorbettoRecipes_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SorbettoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinimumStockLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    SorbettoCost = table.Column<double>(type: "REAL", nullable: true),
                    SorbettoCostDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SorbettoTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SorbettoRecipes_RawMaterialId",
                table: "SorbettoRecipes",
                column: "RawMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SorbettoRecipes");

            migrationBuilder.DropTable(
                name: "SorbettoTypes");
        }
    }
}
