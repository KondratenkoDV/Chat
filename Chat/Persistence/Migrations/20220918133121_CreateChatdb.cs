using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CreateChatdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сomments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HomePage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BrowserData = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сomments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сomments");
        }
    }
}
