using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_SqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    LastRecordedLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMilkCount = table.Column<int>(type: "int", nullable: false),
                    TotalMilkQuantityLiters = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cows", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cows");
        }
    }
}
