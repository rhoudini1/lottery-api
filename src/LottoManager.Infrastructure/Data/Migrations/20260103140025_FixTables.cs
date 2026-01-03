using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LottoManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotteryPrizeHit_Users_LotteryId",
                table: "LotteryPrizeHit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Lottery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lottery",
                table: "Lottery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotteryPrizeHit_Lottery_LotteryId",
                table: "LotteryPrizeHit",
                column: "LotteryId",
                principalTable: "Lottery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotteryPrizeHit_Lottery_LotteryId",
                table: "LotteryPrizeHit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lottery",
                table: "Lottery");

            migrationBuilder.RenameTable(
                name: "Lottery",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotteryPrizeHit_Users_LotteryId",
                table: "LotteryPrizeHit",
                column: "LotteryId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
