using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiCore1.Migrations
{
    public partial class newModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    HistoryId = table.Column<int>(nullable: false),
                    EntityId = table.Column<string>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    ActionType = table.Column<int>(nullable: false),
                    EndHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => new { x.HistoryId, x.EntityId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Action_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewComment",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    ParentCommentId = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewComment_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewComment_NewComment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "NewComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewComment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewComment_AuthorId",
                table: "NewComment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NewComment_ParentCommentId",
                table: "NewComment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_NewComment_PostId",
                table: "NewComment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_AuthorId",
                table: "Action",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AuthorId",
                table: "Post",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewComment");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
