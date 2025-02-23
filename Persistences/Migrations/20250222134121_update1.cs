using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistences.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountStatus",
                table: "SystemAccount",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SystemAccount",
                keyColumn: "AccountID",
                keyValue: (short)1,
                column: "AccountStatus",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountStatus",
                table: "SystemAccount");
        }
    }
}
