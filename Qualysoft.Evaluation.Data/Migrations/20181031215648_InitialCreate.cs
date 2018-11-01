using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualysoft.Evaluation.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true, defaultValue: ""),
                    Visits = table.Column<int>(nullable: true)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 10, 31, 21, 56, 47, 716, DateTimeKind.Utc))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests",
                schema: "dbo");
        }
    }
}
