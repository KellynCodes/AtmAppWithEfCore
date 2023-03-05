using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtmDAL.Migrations
{
    /// <inheritdoc />
    public partial class Indexing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Unique_AccountNoId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_AccountNo",
                table: "Accounts",
                column: "AccountNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Unique_AccountNo",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_AccountNoId",
                table: "Accounts",
                columns: new[] { "AccountNo", "Id" },
                unique: true);
        }
    }
}
