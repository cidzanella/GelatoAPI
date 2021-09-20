using Microsoft.EntityFrameworkCore.Migrations;

namespace GelatoAPI.Data.Migrations
{
    public partial class AddedRawMaterialTypeSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "RawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RawMaterialSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Outro" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "CeleroNacional" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Mayers" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "PopHouse" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Grings" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Apice Sul" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "SanCor" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Destro" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "LeiteSol La Serenissima" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "LAR Supermercado" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Lactobom" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Callebaut" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Fabbri" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "PreGel" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "MEC3" });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Shopping do Sorveteiro" });

            migrationBuilder.InsertData(
                table: "RawMaterialTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 5, "Basica / Variegato" });

            migrationBuilder.InsertData(
                table: "RawMaterialTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Pasta" });

            migrationBuilder.InsertData(
                table: "RawMaterialTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Variegato" });

            migrationBuilder.InsertData(
                table: "RawMaterialTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Pasta / Variegato" });

            migrationBuilder.InsertData(
                table: "RawMaterialTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Basica" });

            migrationBuilder.InsertData(
                table: "RawMaterialTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Fruta" });

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_SupplierId",
                table: "RawMaterials",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_TypeId",
                table: "RawMaterials",
                column: "TypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_RawMaterialSuppliers_SupplierId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_RawMaterialTypes_TypeId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "RawMaterialSuppliers");

            migrationBuilder.DropTable(
                name: "RawMaterialTypes");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_SupplierId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_TypeId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "RawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "RawMaterials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
