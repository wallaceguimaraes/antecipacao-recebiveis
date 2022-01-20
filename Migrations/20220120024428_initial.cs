using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pagcerto");

            migrationBuilder.CreateTable(
                name: "Situations",
                schema: "Pagcerto",
                columns: table => new
                {
                    SituationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situations", x => x.SituationId);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                schema: "Pagcerto",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTransferMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisapprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Early = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationAcquirer = table.Column<string>(type: "varchar(8)", nullable: true),
                    GrossTransferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransferNetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    NumberPlots = table.Column<int>(type: "int", nullable: false),
                    CardDigits = table.Column<int>(type: "int", precision: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "Portions",
                schema: "Pagcerto",
                columns: table => new
                {
                    PortionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<int>(type: "int", nullable: false),
                    GrossValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlotNumber = table.Column<int>(type: "int", nullable: false),
                    AnticipatedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpectedDateReceipt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portions", x => x.PortionId);
                    table.ForeignKey(
                        name: "FK_Portions_Transfer_TransferId",
                        column: x => x.TransferId,
                        principalSchema: "Pagcerto",
                        principalTable: "Transfer",
                        principalColumn: "TransferId");
                });

            migrationBuilder.InsertData(
                schema: "Pagcerto",
                table: "Situations",
                columns: new[] { "SituationId", "Description" },
                values: new object[] { 1, "PENDENTE" });

            migrationBuilder.InsertData(
                schema: "Pagcerto",
                table: "Situations",
                columns: new[] { "SituationId", "Description" },
                values: new object[] { 2, "EM ANÁLISE" });

            migrationBuilder.InsertData(
                schema: "Pagcerto",
                table: "Situations",
                columns: new[] { "SituationId", "Description" },
                values: new object[] { 3, "FINALIZADA" });

            migrationBuilder.CreateIndex(
                name: "IX_Portions_TransferId",
                schema: "Pagcerto",
                table: "Portions",
                column: "TransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portions",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "Situations",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "Transfer",
                schema: "Pagcerto");
        }
    }
}
