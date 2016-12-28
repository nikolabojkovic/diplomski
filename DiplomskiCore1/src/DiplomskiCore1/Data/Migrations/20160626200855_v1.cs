using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiCore1.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDisike",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDisike",
                table: "Blog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "Blog",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDisike",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "NumberOfDisike",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "Blog");

            migrationBuilder.AddColumn<bool>(
                name: "Dislike",
                table: "Comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Like",
                table: "Comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dislike",
                table: "Blog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Like",
                table: "Blog",
                nullable: false,
                defaultValue: false);
        }
    }
}
