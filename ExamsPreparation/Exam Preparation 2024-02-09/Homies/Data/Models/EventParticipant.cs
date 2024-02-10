using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [Required]
        public string HelperId { get; set; } = string.Empty;

        [ForeignKey(nameof(HelperId))]
        public IdentityUser Helper { get; set; } = null!;

        [Required]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;
    }
}
//•	HelperId – a string, Primary Key, foreign key (required)
//•	Helper – IdentityUser
//•	EventId – an integer, Primary Key, foreign key (required)
//•	Event – Event
