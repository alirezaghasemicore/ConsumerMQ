using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exchange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Routing_Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Redelivered = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultLogs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "JsonLogs",
                columns: table => new
                {
                    JsonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogText = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JsonLogs", x => x.JsonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultLogs");

            migrationBuilder.DropTable(
                name: "JsonLogs");
        }
    }
}
