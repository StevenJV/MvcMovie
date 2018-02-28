using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace MvcMovie.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
      using (var mvcMovieContext = new MvcMovieContext(
        serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
      {
        // Look for any directors.
        if (mvcMovieContext.Director.Any())
        {
          return; // If there are any directors in the DB, the seed initializer returns and no directors are added.
        }
        else
        {
          try
          {
            mvcMovieContext.Director.AddRange(
              new Director { Id = -1, Name = "unknown" },
              new Director { Id = 1, Name = "Rob Reiner" },
              new Director { Id = 2, Name = "Ivan Reitman " }
            );
            mvcMovieContext.SaveChanges();
            logger.LogInformation($"Seed Data (director) loaded");
          }
          catch (Exception ex)
          {
            logger.LogError($"Seed Data (director) error: {ex.InnerException.Message}");

          }
        }

        using (var movieContext = new MvcMovieContext(
          serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
        {
          // Look for any movies.
          if (movieContext.Movie.Any())
          {
            return; // If there are any movies in the DB, the seed initializer returns and no movies are added.
          }

          try
          {
            movieContext.Movie.AddRange(
              new Movie
              {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-1-11"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                DirectorID = 1
              },
              new Movie
              {
                Title = "A Few Good Men",
                ReleaseDate = DateTime.Parse("1992-1-11"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                DirectorID = 1
              },
              new Movie
              {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M,
                DirectorID = 2
              },

              new Movie
              {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M,
                DirectorID = 2
              },
              new Movie
              {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("2016-7-15"),
                Genre = "Comedy",
                Price = 8.99M,
                DirectorID = -1
              },
              new Movie
              {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M,
                DirectorID = -1
              }
            );
            movieContext.SaveChanges();
            logger.LogInformation($"Seed Data (move) loaded");
          }
          catch (Exception ex)
          {
            logger.LogError($"Seed Data (movie) error: {ex.InnerException.Message}");

          }
        }
      }
    }
  }
}