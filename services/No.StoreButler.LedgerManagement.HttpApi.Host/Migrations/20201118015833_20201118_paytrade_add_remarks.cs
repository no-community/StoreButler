using Microsoft.EntityFrameworkCore.Migrations;

namespace No.StoreButler.LedgerManagement.Migrations
{
    public partial class _20201118_paytrade_add_remarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "pay_amount",
                table: "LedgerManagementpay_trade",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "LedgerManagementpay_trade",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "LedgerManagementpay_trade");

            migrationBuilder.AlterColumn<long>(
                name: "pay_amount",
                table: "LedgerManagementpay_trade",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
