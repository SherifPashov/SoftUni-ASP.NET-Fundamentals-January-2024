using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    public class SeminarParticipant
    {
        [Required]
        public int SeminarId { get; set; }

        [Required]
        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; } = null!;


        [Required]
        public string ParticipantId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;


    }
}