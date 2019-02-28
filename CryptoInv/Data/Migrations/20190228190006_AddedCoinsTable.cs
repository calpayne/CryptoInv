using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoInv.Data.Migrations
{
    public partial class AddedCoinsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Coins",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "BTC", "Bitcoin" },
                    { "ETH", "Ethereum" },
                    { "BCH", "Bitcoin Cash" },
                    { "LTC", "Litecoin" },
                    { "XMR", "Monero" },
                    { "XLM", "Stellar" },
                    { "XRP", "XRP" },
                    { "ZEC", "Zcash" },
                    { "WAVES", "Waves" },
                    { "DOGE", "Dogecoin" },
                    { "DASH", "Dash" },
                    { "TRX", "TRON" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "BCH");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "BTC");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "DASH");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "DOGE");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "ETH");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "LTC");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "TRX");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "WAVES");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "XLM");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "XMR");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "XRP");

            migrationBuilder.DeleteData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: "ZEC");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Coins");
        }
    }
}
