using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Models;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Director { get; set; } = String.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public string Rating { get; set; } = "0.0";

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>(); 
    }
}
