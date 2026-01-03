using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LottoManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhysicalSlugColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Lottery",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Lottery");
        }
    }
}
