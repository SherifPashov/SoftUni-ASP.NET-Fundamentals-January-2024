using System.ComponentModel.DataAnnotations;
using static Library.Data.Models.DataConstants;

namespace Library.Models
{
    public class BookViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;


        [Required]
        [MinLength(5)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
