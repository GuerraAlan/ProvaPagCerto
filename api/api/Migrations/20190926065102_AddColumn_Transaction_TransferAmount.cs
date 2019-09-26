using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddColumn_Transaction_TransferAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TransferAmount",
                table: "Transaction",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferAmount",
                table: "Transaction");
        }
    }
}
