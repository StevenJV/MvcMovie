using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
  public partial class vw_MovieWithDirector : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      var vw = @"CREATE VIEW[dbo].[MovieWithDirector]
                      AS
                        SELECT  dbo.Movie.ID, dbo.Movie.Title, dbo.Movie.ReleaseDate, dbo.Movie.Genre, dbo.Movie.Price, dbo.Director.Name as DirectorName,  dbo.Movie.Rating
                        FROM    dbo.Movie INNER JOIN 
                                dbo.Director ON dbo.Movie.DirectorID = dbo.Director.Id";
      migrationBuilder.Sql(vw);


    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      var vw = @"DROP VIEW[dbo].[MovieWithDirector]";
      migrationBuilder.Sql(vw);
    }
  }
}
