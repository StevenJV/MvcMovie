using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
      public List<MovieWithDirector> Movies;
      public SelectList Genres;
      public string MovieGenre { get; set; }
    }
}
