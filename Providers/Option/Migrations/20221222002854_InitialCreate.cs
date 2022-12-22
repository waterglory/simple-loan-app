using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple.Loan.App.Providers.Option.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BindingPeriods",
                columns: table => new
                {
                    Length = table.Column<int>(type: "int", precision: 3, nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(8,5)", precision: 8, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BindingPeriods", x => x.Length);
                });

            migrationBuilder.InsertData(
                table: "BindingPeriods",
                columns: new[] { "Length", "InterestRate" },
                values: new object[,]
                {
                    { 1, 2m },
                    { 3, 2.3m },
                    { 6, 2.8m },
                    { 12, 3.3m },
                    { 24, 4m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BindingPeriods");
        }
    }
}
