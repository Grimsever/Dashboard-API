using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.EF.Migrations
{
    public partial class Read_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "income");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "income",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeLists",
                schema: "income",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeLists_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "income",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                schema: "income",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IncomeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PercentSalary = table.Column<int>(type: "integer", nullable: false),
                    IncomedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CurrencyRate = table.Column<double>(type: "double precision", nullable: false),
                    IncomeType = table.Column<int>(type: "integer", nullable: false),
                    CurrencyType = table.Column<int>(type: "integer", nullable: false),
                    IncomeListId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_IncomeLists_IncomeListId",
                        column: x => x.IncomeListId,
                        principalSchema: "income",
                        principalTable: "IncomeLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeLists_UserId",
                schema: "income",
                table: "IncomeLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_IncomeListId",
                schema: "income",
                table: "Incomes",
                column: "IncomeListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes",
                schema: "income");

            migrationBuilder.DropTable(
                name: "IncomeLists",
                schema: "income");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "income");
        }
    }
}
