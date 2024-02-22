using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}