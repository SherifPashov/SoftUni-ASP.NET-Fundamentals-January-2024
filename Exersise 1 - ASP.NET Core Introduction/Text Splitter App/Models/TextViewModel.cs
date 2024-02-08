using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Text_Splitter_App.Models
{
    public class TextViewModel
    {
        [Required]
        [StringLength(30,MinimumLength =2)]
        public string Text { get; set; } = null!;
        public string SolitText { get; set; } = null!;
    }
}
