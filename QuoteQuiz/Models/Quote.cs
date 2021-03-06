﻿using System;
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
        /// has to start with https://www.youtube.com/watch?v=,
        /// regex = /^(https:\/\/youtube\.com\/watch\?v=)[\w]+$/
        /// snip off this portion so it's just the unique video string
        /// example: 7DDxe8FvpPI
        /// </summary>
        [RegularExpression(@"^(https://www.youtube.com/watch\?v=)[\w-_]+$",
                ErrorMessage = "Please provide the full youtube link, example: https://www.youtube.com/watch?v=7DDxe8FvpPI")]
        [Required(ErrorMessage = "Please provide the full youtube link, example: https://www.youtube.com/watch?v=7DDxe8FvpPI")]
        public string Link { get; set; }

        [StringLength(40, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the character's name")]
        public Character Character { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the movie's title")]
        public Movie Movie { get; set; }

    }
}
