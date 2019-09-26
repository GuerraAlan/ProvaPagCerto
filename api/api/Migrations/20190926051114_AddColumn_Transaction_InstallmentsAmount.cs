using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddColumn_Transaction_InstallmentsAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstallmentsAmmount",
                table: "Transaction",
                newName: "InstallmentsAmount");

            migrationBuilder.AddColumn<int>(
                name: "InstallmentsAmmount",
                table: "AdvanceRequest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentsAmmount",
                table: "AdvanceRequest");

            migrationBuilder.RenameColumn(
                name: "InstallmentsAmount",
                table: "Transaction",
                newName: "InstallmentsAmmount");
        }
    }
}
