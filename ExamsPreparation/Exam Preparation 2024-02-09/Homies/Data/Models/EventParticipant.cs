using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [Required]
        public int HelperId  { get; set; }

        [ForeignKey(nameof(HelperId))]
        public string Helper { get; set; } = null!;


        [Required]
        public int EventId   { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;
    }
}