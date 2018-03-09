using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvcMovie.Migrations
{
  public partial class director : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
        name: "DirectorID",
        table: "Movie",
        nullable: false,
        defaultValue: 0);

      migrationBuilder.CreateTable(
        name: "Director",
        columns: table => new
        {
          Id = table.Column<int>(nullable: false)
            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
          Name = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Director", x => x.Id);
        });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Director");

      migrationBuilder.DropColumn(
        name: "DirectorID",
        table: "Movie");
    }
  }
}
