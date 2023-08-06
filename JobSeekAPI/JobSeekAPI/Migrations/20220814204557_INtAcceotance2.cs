using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeekAPI.Migrations
{
    public partial class INtAcceotance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "Acceptance",
                table: "order",
                type: "bit(1)",
                nullable: false,
                defaultValueSql: "b'0'",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "'0'");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "job",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Acceptance",
                table: "order",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'",
                oldClrType: typeof(ulong),
                oldType: "bit(1)",
                oldDefaultValueSql: "b'0'");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "job",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);
        }
    }
}
