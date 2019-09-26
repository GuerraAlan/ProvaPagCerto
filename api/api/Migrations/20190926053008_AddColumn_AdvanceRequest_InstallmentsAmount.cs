using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddColumn_AdvanceRequest_InstallmentsAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstallmentsAmmount",
                table: "AdvanceRequest",
                newName: "InstallmentsAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstallmentsAmount",
                table: "AdvanceRequest",
                newName: "InstallmentsAmmount");
        }
    }
}
