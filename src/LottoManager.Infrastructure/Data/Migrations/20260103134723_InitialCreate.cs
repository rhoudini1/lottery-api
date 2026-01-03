using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LottoManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MinNumber = table.Column<byte>(type: "smallint", nullable: false),
                    MaxNumber = table.Column<byte>(type: "smallint", nullable: false),
                    NumbersToDraw = table.Column<byte>(type: "smallint", nullable: false),
                    SingleBetPrice = table.Column<int>(type: "integer", nullable: false),
                    MaxBetNumberAmount = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotteryPrizeHit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HitNumbers = table.Column<byte>(type: "smallint", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    LotteryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryPrizeHit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotteryPrizeHit_Users_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotteryPrizeHit_LotteryId",
                table: "LotteryPrizeHit",
                column: "LotteryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LotteryPrizeHit");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
