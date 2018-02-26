using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Makes (Name) Values ('Make1')");
            migrationBuilder.Sql("Insert into Makes (Name) Values ('Make2')");
            migrationBuilder.Sql("Insert into Makes (Name) Values ('Make3')");

            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make1-ModelA', (Select ID from Makes where Name = 'Make1'))");
            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make1-ModelB', (Select ID from Makes where Name = 'Make1'))");
            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make1-ModelC', (Select ID from Makes where Name = 'Make1'))");

            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make2-ModelA', (Select ID from Makes where Name = 'Make2'))");
            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make2-ModelB', (Select ID from Makes where Name = 'Make2'))");
            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make2-ModelC', (Select ID from Makes where Name = 'Make2'))");

            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make3-ModelA', (Select ID from Makes where Name = 'Make3'))");
            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make3-ModelB', (Select ID from Makes where Name = 'Make3'))");
            migrationBuilder.Sql("INsert into Models (Name, MakeID) Values ('Make3-ModelC', (Select ID from Makes where Name = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Makes Where Name IN ('Make1', 'Make2', 'Make3')");
        }
    }
}
