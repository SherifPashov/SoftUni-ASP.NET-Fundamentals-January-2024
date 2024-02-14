using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.Models.DataConstants;
namespace Watchlist.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>(); 
    }
}
