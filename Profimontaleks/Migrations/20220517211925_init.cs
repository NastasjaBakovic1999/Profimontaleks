using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Profimontaleks.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhaseStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    GlassThickness = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coefficient = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    NameAndSurname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkerStatusId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Worker_WorkerStatus_WorkerStatusId",
                        column: x => x.WorkerStatusId,
                        principalTable: "WorkerStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCardboard",
                columns: table => new
                {
                    PCCNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCardboard", x => x.PCCNumber);
                    table.ForeignKey(
                        name: "FK_ProductCardboard_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCardboardPhase",
                columns: table => new
                {
                    ProductCardboardId = table.Column<int>(type: "int", nullable: false),
                    PhaseId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCardboardPhase", x => new { x.PhaseId, x.ProductCardboardId });
                    table.ForeignKey(
                        name: "FK_ProductCardboardPhase_Phase_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCardboardPhase_PhaseStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PhaseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCardboardPhase_ProductCardboard_ProductCardboardId",
                        column: x => x.ProductCardboardId,
                        principalTable: "ProductCardboard",
                        principalColumn: "PCCNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Phase",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Secenje i drenaza" },
                    { 2, "Celicno ojacavanje" },
                    { 3, "Varenje uglova" },
                    { 4, "Ciscenje i okivanje" },
                    { 5, "Sklapanje proizvoda" }
                });

            migrationBuilder.InsertData(
                table: "PhaseStatus",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Zapoceto" },
                    { 2, "U toku" },
                    { 3, "Na cekanju" },
                    { 4, "Otkazano" },
                    { 5, "Zavrseno" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 13, "Utovar" },
                    { 12, "Menadzment 3. nivoa" },
                    { 11, "Menadzment 2. nivoa" },
                    { 10, "Menadzment 1. nivoa" },
                    { 9, "Administracija" },
                    { 8, "Razvozenje" },
                    { 7, "Prijem" },
                    { 6, "Pakovanje" },
                    { 5, "Sklapanje" },
                    { 4, "Ciscenje" },
                    { 3, "Varenje" },
                    { 2, "Brusenje" },
                    { 1, "Secenje" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Colour", "Description" },
                values: new object[,]
                {
                    { 15, null, "Plisirani komarnik" },
                    { 16, null, "Venecijaner 25mm" },
                    { 17, null, "Venecijaner 16mm" },
                    { 18, null, "Venecijaner 16x25mm" },
                    { 21, null, "Podprozorska daska" },
                    { 20, null, "Okapnica" },
                    { 14, null, "Americki komarnik" },
                    { 22, null, "ALU roletne" },
                    { 23, null, "PVC roletne" },
                    { 19, null, "Venecijaner 50mm" },
                    { 13, null, "Fiksni komarnik" },
                    { 3, null, "Jednokrilni ALU prozor" },
                    { 11, "Braon", "ALU ulazna vrata ALUMIL 60" },
                    { 10, "Bordo", "ALU ulazna vrata ETEM E-45" },
                    { 9, "Bela", "PVC ulazna vrata Trocal 88" },
                    { 8, "Crna", "PVC ulazna vrata Trocal 76" },
                    { 7, "Braon", "PVC ulazna vrata Trocal 70" },
                    { 6, null, "Sobna ALU vrata" },
                    { 5, null, "Sobna PVC vrata" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Colour", "Description" },
                values: new object[,]
                {
                    { 4, null, "Dvokrilni ALU prozor" },
                    { 2, null, "Dvokrilni PVC prozor" },
                    { 1, null, "Jednokrilni PVC prozor" },
                    { 12, null, "Rolo komarnik" }
                });

            migrationBuilder.InsertData(
                table: "WorkerStatus",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 4, "Pripravnistvo" },
                    { 1, "Privremeno" },
                    { 2, "Za stalno" },
                    { 3, "Praksa" },
                    { 5, "Zamena" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "GlassThickness", "Height", "Length", "ProductTypeId", "Weight" },
                values: new object[,]
                {
                    { 1, 0.18m, 80m, 49m, 1, 2.2m },
                    { 2, 0.18m, 80m, 98m, 2, 4.5m },
                    { 4, 0.18m, 70m, 98m, 2, 4.5m },
                    { 3, 0.18m, 70m, 49m, 3, 2.2m },
                    { 5, 0m, 130m, 102m, 6, 22m },
                    { 7, 0m, 130m, 94m, 6, 20m },
                    { 6, 0m, 133m, 109m, 7, 23m },
                    { 8, 0m, 80m, 104m, 12, 6.3m },
                    { 9, 0m, 110m, 104m, 12, 7.1m },
                    { 10, 0m, 80m, 49m, 12, 4.6m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCardboard_ProductId",
                table: "ProductCardboard",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCardboardPhase_ProductCardboardId",
                table: "ProductCardboardPhase",
                column: "ProductCardboardId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCardboardPhase_StatusId",
                table: "ProductCardboardPhase",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PositionId",
                table: "Worker",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_WorkerStatusId",
                table: "Worker",
                column: "WorkerStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCardboardPhase");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Phase");

            migrationBuilder.DropTable(
                name: "PhaseStatus");

            migrationBuilder.DropTable(
                name: "ProductCardboard");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "WorkerStatus");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
