using Microsoft.EntityFrameworkCore.Migrations;

namespace GelatoAPI.Data.Migrations
{
    public partial class AddedBaseTypeBaseRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_RawMaterialSuppliers_SupplierId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_RawMaterialTypes_TypeId",
                table: "RawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BaseRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RawMaterialId = table.Column<int>(type: "INTEGER", nullable: false),
                    GramsPerKg = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseRecipes_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BaseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Base Branca" });

            migrationBuilder.InsertData(
                table: "BaseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Base Caramello" });

            migrationBuilder.CreateIndex(
                name: "IX_BaseRecipes_RawMaterialId",
                table: "BaseRecipes",
                column: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_RawMaterialSuppliers_SupplierId",
                table: "RawMaterials",
                column: "SupplierId",
                principalTable: "RawMaterialSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_RawMaterialTypes_TypeId",
                table: "RawMaterials",
                column: "TypeId",
                principalTable: "RawMaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_RawMaterialSuppliers_SupplierId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_RawMaterialTypes_TypeId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "BaseRecipes");

            migrationBuilder.DropTable(
                name: "BaseTypes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_RawMaterialSuppliers_SupplierId",
                table: "RawMaterials",
                column: "SupplierId",
                principalTable: "RawMaterialSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_RawMaterialTypes_TypeId",
                table: "RawMaterials",
                column: "TypeId",
                principalTable: "RawMaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
