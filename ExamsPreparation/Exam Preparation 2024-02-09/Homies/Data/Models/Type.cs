using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Data.Models.DataConstants.TypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
