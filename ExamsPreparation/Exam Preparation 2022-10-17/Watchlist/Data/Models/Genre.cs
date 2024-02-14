using static Watchlist.Data.Models.DataConstants;
using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();


    }
}