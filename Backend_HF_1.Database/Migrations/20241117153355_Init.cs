using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_HF_1.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageValue = table.Column<double>(type: "float", nullable: false),
                    MinimalValue = table.Column<int>(type: "int", nullable: false),
                    MaximalValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaterLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterLevels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyStatistics");

            migrationBuilder.DropTable(
                name: "WaterLevels");
        }
    }
}
