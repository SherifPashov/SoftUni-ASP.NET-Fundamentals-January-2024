using System.ComponentModel.DataAnnotations;
using static Library.Data.Models.DataConstants;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
