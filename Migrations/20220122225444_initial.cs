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
                name: "AdvanceRequest",
                schema: "Pagcerto",
                columns: table => new
                {
                    AdvanceRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateAnalysis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnalysisEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnalysisResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountRequestedAdvance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnticipatedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceRequest", x => x.AdvanceRequestId);
                });

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
                    Early = table.Column<string>(type: "varchar(1)", nullable: true),
                    ConfirmationAcquirer = table.Column<string>(type: "varchar(8)", nullable: true),
                    GrossTransferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransferNetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    InstallmentAmount = table.Column<int>(type: "int", nullable: false),
                    CardDigits = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "RequestSituations",
                schema: "Pagcerto",
                columns: table => new
                {
                    RequestSituationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceRequestId = table.Column<int>(type: "int", nullable: false),
                    SituationId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSituations", x => x.RequestSituationId);
                    table.ForeignKey(
                        name: "fk_requested_situation__fk_advance_request",
                        column: x => x.AdvanceRequestId,
                        principalSchema: "Pagcerto",
                        principalTable: "AdvanceRequest",
                        principalColumn: "AdvanceRequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_requested_situation__fk_situation",
                        column: x => x.SituationId,
                        principalSchema: "Pagcerto",
                        principalTable: "Situations",
                        principalColumn: "SituationId",
                        onDelete: ReferentialAction.Cascade);
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
                    InstallmentNumber = table.Column<int>(type: "int", nullable: false),
                    AnticipatedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpectedDateReceipt = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RequestedAdvance",
                schema: "Pagcerto",
                columns: table => new
                {
                    RequestedAdvanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<int>(type: "int", nullable: false),
                    AdvanceRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedAdvance", x => x.RequestedAdvanceId);
                    table.ForeignKey(
                        name: "FK_RequestedAdvance_AdvanceRequest_AdvanceRequestId",
                        column: x => x.AdvanceRequestId,
                        principalSchema: "Pagcerto",
                        principalTable: "AdvanceRequest",
                        principalColumn: "AdvanceRequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestedAdvance_Transfer_TransferId",
                        column: x => x.TransferId,
                        principalSchema: "Pagcerto",
                        principalTable: "Transfer",
                        principalColumn: "TransferId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_RequestedAdvance_AdvanceRequestId",
                schema: "Pagcerto",
                table: "RequestedAdvance",
                column: "AdvanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedAdvance_TransferId",
                schema: "Pagcerto",
                table: "RequestedAdvance",
                column: "TransferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestSituations_AdvanceRequestId",
                schema: "Pagcerto",
                table: "RequestSituations",
                column: "AdvanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSituations_SituationId",
                schema: "Pagcerto",
                table: "RequestSituations",
                column: "SituationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portions",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "RequestedAdvance",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "RequestSituations",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "Transfer",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "AdvanceRequest",
                schema: "Pagcerto");

            migrationBuilder.DropTable(
                name: "Situations",
                schema: "Pagcerto");
        }
    }
}
