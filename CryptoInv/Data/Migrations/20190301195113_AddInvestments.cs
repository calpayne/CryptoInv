using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoInv.Data.Migrations
{
    public partial class AddInvestments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoinId = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    PricePerCoin = table.Column<double>(nullable: false),
                    PricePerCoinEnd = table.Column<double>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    CostEnd = table.Column<double>(nullable: true),
                    InvestmentDate = table.Column<DateTime>(nullable: false),
                    InvestmentDateEnd = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_CoinId",
                table: "Investments",
                column: "CoinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments");
        }
    }
}
