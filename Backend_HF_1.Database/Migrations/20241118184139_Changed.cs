using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_HF_1.Database.Migrations
{
    /// <inheritdoc />
    public partial class Fasz123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyStatistics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageValue = table.Column<double>(type: "float", nullable: false),
                    MaximalValue = table.Column<int>(type: "int", nullable: false),
                    MinimalValue = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyStatistics", x => x.Id);
                });
        }
    }
}
