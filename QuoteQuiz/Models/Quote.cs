using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuoteQuiz.Models
{
    public class Quote
    {
        public int QuoteID { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required(ErrorMessage = "Please enter a longer quote ")]
        public string Text { get; set; }

        /// <summary>
        /// has start with https://www.youtube.com/watch?v=,
        /// snip off this portion so it's just the unique video string
        /// example: 7DDxe8FvpPI
        /// </summary>
        [StringLength(100, MinimumLength = 32)]
        [Required(ErrorMessage = "Please provide the full youtube link: https://www.youtube.com/watch?v=")]
        public string Link { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the character's name")]
        public Character Character { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the movie's title")]
        public Movie Movie { get; set; }

    }
}
