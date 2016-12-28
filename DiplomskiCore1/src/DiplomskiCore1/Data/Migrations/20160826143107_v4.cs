using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiCore1.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogActivity",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    BlogId = table.Column<int>(nullable: false),
                    IsDislike = table.Column<bool>(nullable: false),
                    IsLike = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogActivity", x => new { x.AuthorId, x.BlogId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogActivity");
        }
    }
}
