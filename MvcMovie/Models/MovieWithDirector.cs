using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
  public class MovieWithDirector
  {
    public int ID { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\S-]*$")]
    [Required]
    [StringLength(30)]
    public string Genre { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string DirectorName { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\S-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; }
  }
}
