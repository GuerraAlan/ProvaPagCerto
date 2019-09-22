using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: true),
                    AcquirerConfirmation = table.Column<bool>(nullable: true),
                    TransactionValue = table.Column<double>(nullable: false),
                    InstallmentsAmmount = table.Column<int>(nullable: false),
                    CardLastDigits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvanceRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    TransactionId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InitialAnalysisDate = table.Column<DateTime>(nullable: true),
                    DoneAnalysisDate = table.Column<DateTime>(nullable: true),
                    AnalysisResult = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceRequest_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceRequest_TransactionId",
                table: "AdvanceRequest",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvanceRequest");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
